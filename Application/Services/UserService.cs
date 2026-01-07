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
    internal class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<User?> GetById(Guid id)
        {
            return _userRepository.GetUser(id);
        }

        public Task<User?> GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public BaseResponse<LoginResponseModel> Login(LoginRequestModel model)
        {
            var userName = _userRepository.GetUserByUsername(model.UserName);
                if(userName == null)
                {
                    return new BaseResponse<LoginResponseModel>
                    {
                        Status = false,
                        Message = "Login Failed",
                        Data = null
                    };
                }
                var user = new User
                {
                    UserName = model.UserName,
                    HashPassword = model.Password
                };
                return new BaseResponse<LoginResponseModel>
                {
                    Status = true,
                    Message = "Login Successful",
                    Data = new LoginResponseModel
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Role = user.Role
                    }

                };
        }
    }
}
