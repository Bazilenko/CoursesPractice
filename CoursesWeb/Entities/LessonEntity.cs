namespace DAL.Entities
{
    public class LessonEntity
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string? VideoUrl { get; set; }
        public string? VideoTitle { get; set; }
        public string? AudioUrl { get; set; }
        public string? AudioTitle { get; set; }
        public string TextContent { get; set; }
        public DateTime Date { get; set; }
        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }
        public int TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }
        public ICollection<AssignmentEntity> Assignments { get; set; }
        public ICollection<AttendanceEntity> Attendances { get; set; }

    }
}