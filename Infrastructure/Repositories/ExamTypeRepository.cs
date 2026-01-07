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
    public class ExamTypeRepository : IExamTypeRepository
    {
        private readonly AppDbContext _context;
        public ExamTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ExamType examType)
        {
            await _context.Set<ExamType>().AddAsync(examType);
        }

        public async Task<ICollection<ExamType>> GetAllAsync()
        {
            return await _context.Set<ExamType>().ToListAsync();
        }

        public async Task<ExamType> GetAsync(Guid id)
        {
            return await _context.Set<ExamType>().FirstOrDefaultAsync(exam => exam.Id == id);
        }
    }
}
