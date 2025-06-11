using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Instructor
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();
    }

}
