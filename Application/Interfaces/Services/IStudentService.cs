using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IStudentService
    {
        Task<BaseResponse<RegisterStudentResponseModel>> RegisterAsync(RegisterStudentRequestModel model);
        Task<BaseResponse<StudentDto>> GetStudentAsync(Guid id);
        Task<BaseResponse<ICollection<StudentDto>>> GetAllStudentsAsync(Guid id);
        Task<BaseResponse<ICollection<StudentDto>>> GetAllStudentsByGuardianId(Guid guardianId);
    }
}
