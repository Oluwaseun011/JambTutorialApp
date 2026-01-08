using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExamType : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price {  get; set; } 
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
        public ICollection<StudentExamType> StudentExamTypes { get; set; } = new HashSet<StudentExamType>();
    }
}
