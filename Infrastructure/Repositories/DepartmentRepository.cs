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

        public async Task<Department?> GetDepartmentAsync(Guid id)
        {
            return await _context
                .Set<Department>()
                .Include(a =>a.ExamType)
                .Include(a => a.StudentDepartments)
                .ThenInclude(a => a.Student)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Department>> GetDepartmentsAsync()
        {
            return await _context.Set<Department>().ToListAsync();
        }

        public async Task<ICollection<Department>> GetDepartmentsByExamTypeAsync(Guid examTypeId)
        {
            return await _context
                .Set<Department>()
                .Include(a => a.StudentDepartments)
                .ThenInclude(a => a.Student)
                .Where(a => a.ExamTypeId == examTypeId)
                .ToListAsync();
        }

        public async Task<bool> IsExistAsync(string name)
        {
            return await _context .Set<Department>().AnyAsync(x => x.Name == name);
        }
    }
}
