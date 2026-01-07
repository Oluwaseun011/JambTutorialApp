using Application.Dtos;
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
        Task AddSession(SessionRequestModel model);
        Task Delete(Guid Id);
        Task<List<Session>> GetAllSessions();
    }
}
