using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Department : BaseEntity
    {
        public Guid ExamTypeId { get; set; }
        public ExamType ExamType { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Subjects { get; set; } = default!;
        public ICollection<StudentDepartment> StudentDepartments { get; set; } = new HashSet<StudentDepartment>();
    }
}
