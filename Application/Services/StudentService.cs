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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        public StudentService(IStudentRepository studentRepository, IUserRepository userRepository)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
        }
        public async Task<BaseResponse<ICollection<StudentDto>>> GetAllStudentsAsync()
        {
            var response = await _studentRepository.GetStudentsAsync();
            if(response is  null)
            {
                return new BaseResponse<ICollection<StudentDto>>
                {
                    Status = false,
                    Message = "No student found",
                    Data = null
                };
            }
            return new BaseResponse<ICollection<StudentDto>>
            {
                Status = true,
                Message = "Successful",
                Data = response.Select(student => new StudentDto
                {
                    Id = student.Id,
                    UserName = student.UserName,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email
                }).ToList()
            };
        }

        public async Task<BaseResponse<StudentDto>> GetStudentAsync(string username)
        {
            var response = await _studentRepository.GetStudentAsync(username);
            if(response is null)
            {
                return new BaseResponse<StudentDto>
                {
                    Status = false,
                    Message = "Student not found",
                    Data = null
                };
            }
            return new BaseResponse<StudentDto>
            {
                Status = true,
                Message = "Message",
                Data = new StudentDto
                {
                    Id = response.Id,
                    UserName = response.UserName,
                    FirstName = response.FirstName,
                    LastName = response.LastName,
                    Email = response.Email
                }
            };
        }

        public async Task<BaseResponse<RegisterStudentResponseModel>> RegisterAsync(RegisterStudentRequestModel model)
        {
            var student = new Student()
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                Dob = model.Dob
            };
            await _studentRepository.AddAsync(student);
            var user = new User()
            {
                UserName = student.UserName,
                HashPassword = model.Password
            };
            await _userRepository.CreateUserAsync(user);
            return new BaseResponse<RegisterStudentResponseModel>()
            {
                Status = true,
                Message = "Registration successful",
                Data = new RegisterStudentResponseModel
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                }
            };
        }
    }
}
