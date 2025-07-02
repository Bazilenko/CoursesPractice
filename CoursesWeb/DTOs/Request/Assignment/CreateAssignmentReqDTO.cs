namespace CoursesWeb.DTOs.Request.Assignment
{
    public class CreateAssignmentReqDTO
    {
        public string Tittle { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int LessonId { get; set; }
    }
}
