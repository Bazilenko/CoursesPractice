namespace CoursesWeb.DTOs.Response
{
    public class TeacherMiniResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? Experience { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
    }
}
