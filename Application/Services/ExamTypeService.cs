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
using System.Threading.Tasks;

namespace Application.Services
{
    public class ExamTypeService : IExamTypeService
    {
        private readonly IExamTypeRepository _examTypeRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly IUnitOfWork _unitOfWork;
        public ExamTypeService(IExamTypeRepository examTypeRepository, IMemoryCache memoryCache, IUnitOfWork unitOfWork)
        {
            _examTypeRepository = examTypeRepository;
            _memoryCache = memoryCache;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Guid>> Create(CreateExamTypeRequestModel model)
        {
            var examTypeExist = await _examTypeRepository.IsExistAsync(model.Name);
            if (examTypeExist) return BaseResponse<Guid>.Failure("Already exist");
            var examType = new ExamType
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };
            await _examTypeRepository.AddAsync(examType);
            await _unitOfWork.SaveAsync();

            _memoryCache.Remove(CacheKeys.all_examTypes);
            return BaseResponse<Guid>.Success(examType.Id, "Created Successfully");

        }

        public async Task<BaseResponse<ExamTypeDto?>> GetExamType(Guid id)
        {
            var examType = await _examTypeRepository.GetAsync(id);
            if (examType is null)return BaseResponse<ExamTypeDto?>.Failure("Not found");

            var dto = new ExamTypeDto
            {
                Id = examType.Id,
                Name = examType.Name,
                Description = examType.Description,
                Price = examType.Price
            };
            return BaseResponse<ExamTypeDto?>.Success(dto, "successful");
        }

        public async Task<BaseResponse<IEnumerable<ExamTypeDto?>>> GetExamTypes()
        {
            if(!_memoryCache.TryGetValue(CacheKeys.all_examTypes, out IEnumerable<ExamTypeDto?> examTypes))
            {
                var allExamTypes = await _examTypeRepository.GetAllAsync();
                examTypes = allExamTypes.Select(x => new ExamTypeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price
                }).ToList();

                _memoryCache.Set(CacheKeys.all_examTypes, examTypes);
            }
            return BaseResponse<IEnumerable<ExamTypeDto?>>.Success(examTypes, "successful");
        }
    }
}
