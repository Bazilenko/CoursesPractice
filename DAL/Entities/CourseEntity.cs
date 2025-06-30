namespace DAL.Entities
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
        public int QuantityOfLessons { get; set; }
        public decimal Discount {  get; set; } = decimal.Zero;

        public ICollection<LessonEntity> Lessons { get; set; }
        public ICollection<EnrollmentEntity> Enrollments { get; set; }
        

    }
}
