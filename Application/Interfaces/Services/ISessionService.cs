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

        Task<BaseResponse<Guid>> Create(CreateSessionRequestModel model);
        Task<BaseResponse<SessionDto?>> Get(Guid Id);
        Task<BaseResponse<IEnumerable<SessionDto>>> GetSessions();
    }
}
