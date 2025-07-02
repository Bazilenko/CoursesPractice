using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class AttendanceEntity
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int LessonId { get; set; }
        public LessonEntity Lesson { get; set; }
        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }

    }
}
