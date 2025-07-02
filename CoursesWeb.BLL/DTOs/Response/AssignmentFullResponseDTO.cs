namespace CoursesWeb.DTOs.Response
{
    public class AssignmentFullResponseDTO
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int LessonId { get; set; }
    }
}
