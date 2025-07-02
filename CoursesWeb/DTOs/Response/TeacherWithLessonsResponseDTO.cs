namespace CoursesWeb.DTOs.Response
{
    public class TeacherWithLessonsResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;

        public List<LessonMiniResponseDTO> Lessons { get; set; } = new();
    }
}
