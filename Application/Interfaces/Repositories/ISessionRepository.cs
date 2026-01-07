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

        Task AddsessionAssyn(Session session);
        void Delete(Guid id);
        void Updatesession(Session session);
        Task<Session> GetSessionAsync(Guid id);
        Task<ICollection<Session>> GetSessionsAsync();

    }
}
