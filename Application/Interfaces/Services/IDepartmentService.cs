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
        public void Add(Department department);
        public Department GetDepartment(Guid id);
        public ICollection<Department> GetAllDepartment();
        public ICollection<Department> GetDepartmentsByExamType(Guid examTypeId);
    }
}
