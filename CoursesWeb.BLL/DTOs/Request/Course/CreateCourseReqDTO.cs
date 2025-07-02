using System.ComponentModel.DataAnnotations;

namespace CoursesWeb.DTOs.Request.Course
{
    public class CreateCourseReqDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public decimal Price { get; set; }
        public int QuantityOfLessons { get; set; }
        public decimal Discount { get; set; }
    }
}
