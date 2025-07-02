namespace CoursesWeb.DTOs.Request.Submission
{
    public class SubmissionCreateReqDTO
    {
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public string? Grade { get; set; }
    }
}
