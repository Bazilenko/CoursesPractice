namespace CoursesWeb.DTOs.Request.Lesson
{
    public class LessonCreateReqDTO
    {
        public string Tittle { get; set; }
        public string? VideoUrl { get; set; }
        public string? VideoTitle { get; set; }
        public string? AudioUrl { get; set; }
        public string? AudioTitle { get; set; }
        public string TextContent { get; set; }
        public DateTime Date { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
    }
}
