using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ExamTypeDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public ICollection<StudentExamType> StudentExamTypes { get; set; } = new HashSet<StudentExamType>();
    }
    public record ExamTypeRequestModel(string Name, string Description, decimal Price);
    public record ExamTypeResponseModel(Guid Id, string Name);
}
