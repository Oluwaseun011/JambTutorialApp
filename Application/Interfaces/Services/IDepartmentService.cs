using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<BaseResponse<DepartmentResponseModel>> Add(DepartmentRequestModel department);
        Task<BaseResponse<DepartmentDto?>> GetDepartment(Guid id);
        Task<BaseResponse<ICollection<DepartmentDto>>> GetAllDepartments();
        Task<BaseResponse<ICollection<Department>>> GetDepartmentsByExamType(Guid examTypeId);
    }
}
