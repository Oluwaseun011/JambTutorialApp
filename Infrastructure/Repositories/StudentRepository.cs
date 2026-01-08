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
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Student student)
        {
            await _dbContext.Set<Student>().AddAsync(student);
        }

        public void Delete(Student student)
        {
             _dbContext.Remove(student);
        }

        public async Task<Student?> GetStudentAsync(string userName)
        {
            return await _dbContext.Set<Student>().FirstOrDefaultAsync(a => a.UserName == userName);
        }

        public async Task<Student?> GetStudentAsync(Guid id)
        {
            return await _dbContext.Set<Student>().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<ICollection<Student>> GetStudentsAsync()
        {
            return await _dbContext.Set<Student>().ToListAsync();  
        }

        public void Update(Student student)
        {
            _dbContext.Update(student);
        }
    }
}
