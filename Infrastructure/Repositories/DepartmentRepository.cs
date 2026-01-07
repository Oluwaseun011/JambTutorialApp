using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Department department)
        {
            await _context.Set<Department>().AddAsync(department);
        }

        public async Task<Department> GetDepartmentAsync(Guid id)
        {
            return await _context.Set<Department>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Department>> GetDepartmentsAsync()
        {
            return await _context.Set<Department>().ToListAsync();
        }

        public async Task<ICollection<Department>> GetDepartmentsAsyncByExamType(Guid examTypeId)
        {
            return await _context.Set<Department>().Where(a => a.ExamTypeId == examTypeId).Include(x => x.ExamType).ToListAsync();
        }
    }
}
