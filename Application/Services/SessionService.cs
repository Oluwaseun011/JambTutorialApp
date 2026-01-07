using Application.Dtos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SessionService:ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        public async Task<SessionResponseModel> AddSession(SessionRequestModel model)
        {
            Session session = new Session
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
            };
            _sessionRepository.AddsessionAssyn(session);
            return new SessionResponseModel(session.Id, session.Name);
        }

        public async Task Delete(Guid Id)
        {
            _sessionRepository.Delete(Id);
        }
       
        public async Task<Session?> Get(Guid Id)
        {
            return await _sessionRepository.GetSessionAsync(Id);

        }
        public Task<ICollection<Session>> GetAllSessions()
        {
            return _sessionRepository.GetSessionsAsync();
        }

        public Task Update(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
