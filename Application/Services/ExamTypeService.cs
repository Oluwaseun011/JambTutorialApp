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
    public class ExamTypeService : IExamTypeService
    {
        private readonly IExamTypeRepository _examTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ExamTypeService(IExamTypeRepository examTypeRepository, IUnitOfWork unitOfWork)
        {
            _examTypeRepository = examTypeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<ExamTypeResponseModel>> Create(ExamTypeRequestModel model)
        {
            var examType = new ExamType
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };
            await _examTypeRepository.AddAsync(examType);
            await _unitOfWork.SaveAsync();
            return new BaseResponse<ExamTypeResponseModel>
            {
                Status = true,
                Data = new ExamTypeResponseModel
                {
                    Id = examType.Id,
                    Name = examType.Name
                }

            };

        }

        public async Task<BaseResponse<ICollection<ExamTypeDto>>> GetAllExamTypes()
        {
            var listOfExamType = await _examTypeRepository.GetAllAsync();
            if (listOfExamType is null)
            {
                return new BaseResponse<ICollection<ExamTypeDto>>
                {
                    Status = false,
                    Data = null
                };
                
             }
            return new BaseResponse<ICollection<ExamTypeDto>>
            {
                Status = true,
                Data = listOfExamType.Select(x => new ExamTypeDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };
        }

        public async Task<BaseResponse<ExamTypeDto>> GetExamType(Guid id)
        {
            var response = await _examTypeRepository.GetAsync(id);
            if (response is null) return new BaseResponse<ExamTypeDto>
            {
                Status = false,
                Data = null
            };
            return new BaseResponse<ExamTypeDto>
            {
                Status = true,
                Data = new ExamTypeDto
                {
                    Id = id,
                    Name = response.Name
                }
            };
        }
    }
}
