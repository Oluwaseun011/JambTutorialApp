using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IExamTypeRepository 
    {
        Task AddAsync(ExamType examType);
        Task<ExamType> GetAsync(Guid id);
        Task<ICollection<ExamType>> GetAllAsync();
    }
}
