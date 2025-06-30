using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class EnrollmentEntity
    {
        public int Id { get; set; }
        public DateTime EnrolledAt { get; set; }
        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }
        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }
    }
}
