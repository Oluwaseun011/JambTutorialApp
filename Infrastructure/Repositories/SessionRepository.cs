using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        public readonly AppDbContext _dbContext;
        public SessionRepository (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddsessionAssyn(Domain.Entities.Session session)
        {
            await _dbContext.Set<Domain.Entities.Session>().AddAsync(session);
        }

        public void Delete(Guid id)
        {
            _dbContext.Remove(id);
        }

        public async Task<Domain.Entities.Session> GetSessionAsync(Guid id)
        {
            return await _dbContext.Set<Domain.Entities.Session>().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<ICollection<Domain.Entities.Session>> GetSessionsAsync()
        {
            return await _dbContext.Set<Domain.Entities.Session>().ToListAsync();
        }

        public void UpdateSession(Domain.Entities.Session session)

        {
            _dbContext.Update(session);
        }

        public void Updatesession(Domain.Entities.Session session)
        {
            throw new NotImplementedException();
        }
    }
}
