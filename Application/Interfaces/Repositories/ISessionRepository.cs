using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
   public interface ISessionRepository
    {

        Task AddAsync(Session session);
        Task<Session?> GetSessionAsync(Guid id);
        Task<ICollection<Session>> GetSessionsAsync();
        void Update(Session session);
        void Delete(Session session);

    }
}
