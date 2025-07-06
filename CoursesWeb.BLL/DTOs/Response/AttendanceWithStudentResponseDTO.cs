using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesWeb.BLL.DTOs.Response
{
    public class AttendanceWithStudentResponseDTO
    {
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string Status { get; set; }
        public string LessonTittle { get; set; }
        public DateTime Date { get; set; }
    }
}
