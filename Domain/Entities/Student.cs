using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string ImgeUrl { get; set; } = default!;
        public Gender Gender { get; set; }
        public DateTime Dob {  get; set; }
        public int Age => DateTime.UtcNow.Year - Dob.Year;
        public ICollection<StudentExamType> StudentExamTypes { get; set; } = new HashSet<StudentExamType>();
        public ICollection<StudentDepartment> StudentDepartments { get; set; } = new HashSet<StudentDepartment>();
    }
}
