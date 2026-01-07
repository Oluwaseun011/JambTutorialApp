using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task AddAsync(Department department);
        Task<Department> GetDepartmentAsync(Guid id);
        Task<ICollection<Department>> GetDepartmentsAsync();
        Task<ICollection<Department>> GetDepartmentsAsyncByExamType(Guid examTypeId);
    }
}
