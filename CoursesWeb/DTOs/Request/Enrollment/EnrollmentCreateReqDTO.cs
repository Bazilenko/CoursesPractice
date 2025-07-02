using Microsoft.VisualBasic;

namespace CoursesWeb.DTOs.Request.Enrollment
{
    public class EnrollmentCreateReqDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
    }
}
