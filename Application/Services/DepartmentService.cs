using Application.Constants;
using Application.Dtos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IDepartmentRepository repository, IMemoryCache cache, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _cache = cache;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Guid>> Create(CreateDepartmentRequestModel model)
        {
            var deptExist = await _repository.IsExistAsync(model.Name);
            if (deptExist) return BaseResponse<Guid>.Failure("Already exist");

            var dept = new Department
            {
                Name = model.Name,
                ExamTypeId = model.ExamTypeId
            };

            await _repository.AddAsync(dept);
            await _unitOfWork.SaveAsync();

            _cache.Remove(CacheKeys.all_departments);
            return BaseResponse<Guid>.Success(dept.Id, "created successfully");
        }

        public Task<BaseResponse<DepartmentDto?>> GetDepartment(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            if(!_cache.TryGetValue(CacheKeys.all_departments, out IEnumerable<DepartmentDto> departments))
            {
                var allDepartments = await _repository.GetDepartmentsAsync();

                departments = allDepartments.Select(a => new DepartmentDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    ExamTypeId = a.ExamTypeId,
                    ExamTypeName = a.ExamType.Name,
                    Subjects = JsonSerializer.Deserialize<List<string>>(a.Subjects)
                }).ToList();

                _cache.Set(CacheKeys.all_departments, departments);
            }
            return BaseResponse<IEnumerable<DepartmentDto>>.Success(departments, "successful");
        }

        public Task<BaseResponse<ICollection<DepartmentDto>>> GetDepartmentsByExamType(Guid examTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
