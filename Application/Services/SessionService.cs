using Application.Constants;
using Application.Dtos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SessionService:ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IMemoryCache  _cache;
        private readonly IUnitOfWork _unitOfWork;
        public SessionService(ISessionRepository sessionRepository, IMemoryCache cache, IUnitOfWork unitOfWork)
        {
            _sessionRepository = sessionRepository;
            _cache = cache;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Guid>> Create(CreateSessionRequestModel model)
        {

            var sessionExist = await _sessionRepository.IsExistAsync(model.Name);
            if (sessionExist) return BaseResponse<Guid>.Failure("Already exist");
            var session = new Session
            {
                 Name = model.Name,
            };
            await _sessionRepository.AddAsync(session);
            await _unitOfWork.SaveAsync();


            _cache.Remove(CacheKeys.all_session);
            return BaseResponse<Guid>.Success(session.Id, "created successfully");
        }

        public async Task<BaseResponse<SessionDto?>> Get(Guid Id)
        {
            var response = await _sessionRepository.GetSessionAsync(Id);
            if (response == null)
            {
                return BaseResponse<SessionDto?>.Failure("Sessions not Found");
            }
            var session = new SessionDto
            {
                Name = response.Name,
            };
            return BaseResponse<SessionDto?>.Success(session, "Successful");
        }

        public async Task<BaseResponse<IEnumerable<SessionDto>>> GetSessions()
        {
            if (!_cache.TryGetValue(CacheKeys.all_session, out IEnumerable<SessionDto> sessions))
            {
                var allSession = await _sessionRepository.GetSessionsAsync();


                sessions = allSession.Select(a => new SessionDto
                {
                    Id = a.Id,
                    Name = a.Name,
                }).ToList();

                _cache.Set(CacheKeys.all_session, sessions);
            }
            return BaseResponse<IEnumerable<SessionDto>>.Success(sessions, "successful");
        }
    }
}
