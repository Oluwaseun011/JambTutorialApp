using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IExamTypeService
    {
        Task<BaseResponse<ExamTypeResponseModel>> Create (ExamTypeRequestModel model);
        Task<BaseResponse<ExamTypeDto?>> GetExamType (Guid id);
        Task<BaseResponse<ICollection<ExamTypeDto?>>> GetAllExamTypes ();
    }
}
