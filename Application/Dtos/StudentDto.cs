using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string ImgeUrl { get; set; } = default!;
        public Gender Gender { get; set; }
        public DateTime Dob { get; set; }
        public ICollection<ExamTypeDto> ExamTypes { get; set; } = new HashSet<ExamTypeDto>();
        public ICollection<DepartmentDto> Departments { get; set; } = new HashSet<DepartmentDto>();
    }

    public class RegisterStudentRequestModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public IFormFile ImgeUrl { get; set; } = default!;
        public Gender Gender { get; set; }
        public DateTime Dob { get; set; }
    }
}
