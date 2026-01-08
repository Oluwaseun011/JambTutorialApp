using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public Guid ExamTypeId { get; set; }
        public string ExamTypeName { get; set; } = default!;
        public string Name { get; set; } = default!;
        public ICollection<string> Subjects { get; set; } = new HashSet<string>();
    }
    public class CreateDepartmentRequestModel
    {
        public Guid ExamTypeId { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<string> Subjects { get; set; } = new HashSet<string>();
    }
}
