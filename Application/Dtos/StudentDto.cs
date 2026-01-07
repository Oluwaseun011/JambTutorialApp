using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class StudentDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; } = default!;
        public string HashPassword { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public Gender Gender { get; set; }
        public DateTime Dob { get; set; }
    }

    public class RegisterStudentRequestModel
    {
        public string UserName { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string HashPassword { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public Gender Gender { get; set; }
        public DateTime Dob { get; set; }
    }

    public class RegisterStudentResponseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}
