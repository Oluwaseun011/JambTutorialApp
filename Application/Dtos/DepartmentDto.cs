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
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ExamTypeId { get; set; }
        public ExamType ExamType { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Subjects { get; set; } = default!;
        public ICollection<StudentExamType> ExamTypes { get; set; } = new HashSet<StudentExamType>();
    }
    public record DepartmentRequestModel(ExamType ExamType, string Name, string Subjects);
    public record DepartmentResponseModel(Guid Id, Guid ExamTypeId, string Name, string Subjects);
}
