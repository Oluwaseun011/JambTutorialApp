using Application.Dtos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        //IDepartmentRepository _repository = new DepartmentRepository();
       
        async Task<BaseResponse<DepartmentResponseModel>> IDepartmentService.Add(DepartmentRequestModel departmentRequestModel)
        {
            Department department = new Department
            {
                ExamType = departmentRequestModel.ExamType,
                Name = departmentRequestModel.Name,
                Subjects = departmentRequestModel.Subjects,
            };
            _repository.AddAsync(department);

            return new BaseResponse<DepartmentResponseModel>
            {
                Status = true,
                Message = $"Department created successfully.",
                Data = new DepartmentResponseModel
                (
                    departmentRequestModel.Name,
                    departmentRequestModel.Subjects
                    )
            };
        }

        async Task<BaseResponse<ICollection<DepartmentDto>>> IDepartmentService.GetAllDepartments()
        {
            _repository.GetDepartmentsAsync();
            return new BaseResponse<ICollection<DepartmentDto>>
            {
                Status = true,
                Message = "",
                Data = new List<DepartmentDto>
                (
                    
                    )
            };
        }

        async Task<BaseResponse<DepartmentDto?>> IDepartmentService.GetDepartment(Guid id)
        {
            _repository.GetDepartmentAsync(id);
            return new BaseResponse<DepartmentDto?>
            { 
                Status = true,
                Message = "",
                Data = new DepartmentDto
                (
          
                    )
            };
        }

        async Task<BaseResponse<ICollection<Department>>> IDepartmentService.GetDepartmentsByExamType(Guid examTypeId)
        {
            _repository.GetDepartmentsAsyncByExamType(examTypeId);
            return new BaseResponse<ICollection<Department>>
            {
                Status = true,
                Message = "",
                Data = new List<Department>
                (

                    )
            };
        }
    }
}
