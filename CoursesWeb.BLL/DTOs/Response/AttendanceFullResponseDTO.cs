namespace CoursesWeb.DTOs.Response
{
    public class AttendanceFullResponseDTO
    {
        public int Id { get; set; }
        public string Status { get; set; } = null!;

        public LessonMiniResponseDTO Lesson { get; set; } = null!;
        public StudentMiniResponseDTO Student { get; set; } = null!;
    }
}
