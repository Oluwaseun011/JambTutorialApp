using Application.Constants;
using Application.Dtos;
using Application.Interfaces.External;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadService _upload;
        public StudentService(IStudentRepository studentRepository, IMemoryCache cache, IUnitOfWork unitOfWork, IUploadService upload)
        {
            _studentRepository = studentRepository;
            _cache = cache;
            _unitOfWork = unitOfWork;
            _upload = upload;
        }
        public async Task<BaseResponse<IEnumerable<StudentDto>>> GetAllStudentsAsync()
        {
            if(!_cache.TryGetValue(CacheKeys.all_students, out IEnumerable<StudentDto> students))
            {
                var allStudents = await _studentRepository.GetStudentsAsync();
                students = allStudents.Select(a => new StudentDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    UserName = a.UserName,
                    Email = a.Email,
                    PhoneNumber = a.PhoneNumber,
                    ImgeUrl = a.ImgeUrl,
                    Gender = a.Gender,
                    Dob = a.Dob,
                }).ToList();
                _cache.Set(CacheKeys.all_students, students);
            }
            return BaseResponse<IEnumerable<StudentDto>>.Success(students, "Successful");
           
        }

        public async Task<BaseResponse<StudentDto?>> GetStudentAsync(string username)
        {
            var response = await _studentRepository.GetStudentAsync(username);
            if (response == null) return BaseResponse<StudentDto>.Failure("Not found");
            var student = new StudentDto
            {
                FirstName = response.FirstName,
                LastName = response.LastName,
                UserName = response.UserName,
                Email = response.Email,
                PhoneNumber = response.PhoneNumber,
                ImgeUrl = response.ImgeUrl,
                Gender = response.Gender,
                Dob = response.Dob
            };
            return BaseResponse<StudentDto?>.Success(student, "Successful");
        }

        public async Task<BaseResponse<Guid>> RegisterAsync(RegisterStudentRequestModel model)
        {
            var studentExist = await _studentRepository.IsExist(model.UserName);
            if (studentExist) return BaseResponse<Guid>.Failure("Already exist");
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                Dob = model.Dob,
                ImgeUrl = await _upload.UploadImage(model.ImgeUrl)
            };
            await _studentRepository.AddAsync(student);
            await _unitOfWork.SaveAsync();

            _cache.Remove(CacheKeys.all_students);
            return BaseResponse<Guid>.Success(student.Id, "Registration successful");
        }
    }
}
