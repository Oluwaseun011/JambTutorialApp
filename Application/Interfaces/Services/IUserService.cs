using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    internal interface IUserService
    {

        BaseResponse<LoginResponseModel> Login(LoginRequestModel model);
        Task<User> GetByUsername(string username);
        Task<User> GetById(Guid id);
    }
}
