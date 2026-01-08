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
        Task<BaseResponse<Guid>> Create(CreateDepartmentRequestModel model);
        Task<BaseResponse<DepartmentDto?>> GetDepartment(Guid id);
        Task<BaseResponse<IEnumerable<DepartmentDto>>> GetDepartments();
        Task<BaseResponse<ICollection<DepartmentDto>>> GetDepartmentsByExamType(Guid examTypeId);
    }
}
