using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task AddAsync(Student student);
        Task<Student> GetStudentByIdAsync(Guid id);
        Task<Student> GetStudentAsync(string userName);
        void Delete(Guid id);
        void Update(Student student);
        Task<ICollection<Student>> GetStudentsAsync();
    }
}
