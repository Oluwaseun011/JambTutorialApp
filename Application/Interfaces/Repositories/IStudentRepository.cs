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
        Task<Student?> GetStudentAsync(Guid id);
        Task<Student?> GetStudentAsync(string userName);
        Task<ICollection<Student>> GetStudentsAsync();
        void Update(Student student);
        void Delete(Student student);
    }
}
