using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class LessonEntity
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string? VideoUrl { get; set; }
        public string? VideoTitle { get; set; }
        public string? AudioUrl { get; set; }
        public string? AudioTitle { get; set; }
        public string TextContent { get; set; }
        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }
        public int TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }

    }
}
