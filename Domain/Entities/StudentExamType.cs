using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StudentExamType
    {
        public Guid Id {  get; set; } = Guid.NewGuid();
        public Guid StudentId { get; set; }
        public Student Student { get; set; } = default!;
        public Guid ExamTypeId { get; set; }
        public ExamType ExamType { get; set; } = default!;
    }
}
