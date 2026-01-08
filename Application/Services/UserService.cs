using Application.Dtos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<BaseResponse<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await _userRepository.GetUserAsync(model.UserName);
            if (user is null) return BaseResponse<LoginResponseModel>.Failure("Not found !");
            
            string passwordWithSalt = $"{user.Salt}{model.Password}";
            var result = _passwordHasher.VerifyHashedPassword(user, user.HashPassword, passwordWithSalt);

            if (result == PasswordVerificationResult.Failed) return BaseResponse<LoginResponseModel>.Failure("Invalid Credentials");

            var response = new LoginResponseModel
            {
                Id = user!.Id,
                UserName = user.UserName,
                Role = user.Role
            };

            return BaseResponse<LoginResponseModel>.Success(response, "logged in successful");
        }
    }
}
