using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string Level { get; set; }
        public decimal Price { get; set; }
        [Range(1, 120)]
        public int QuantityOfLessons { get; set; }
        [Range(1, 100)]
        public decimal Discount {  get; set; } = decimal.One;

        public ICollection<LessonEntity> Lessons { get; set; }
        public ICollection<EnrollmentEntity> Enrollments { get; set; }
        

    }
}
