using Application.Dtos;
using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ISessionService
    {

        Task<SessionResponseModel> AddSession(SessionRequestModel model);
        Task Delete(Guid Id);
        Task Update(Guid Id);
         Task<Session?> Get(Guid Id);
        Task<ICollection<Session>> GetAllSessions();
    }
}
