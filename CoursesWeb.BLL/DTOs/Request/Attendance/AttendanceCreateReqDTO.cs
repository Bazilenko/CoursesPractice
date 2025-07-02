namespace CoursesWeb.DTOs.Request.Attendance
{
    public class AttendanceCreateReqDTO
    {
        public string Status { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
    }
}
