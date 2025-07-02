using System.ComponentModel.DataAnnotations;

namespace CoursesWeb.DTOs.Response
{
    public class CourseFullResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public decimal Price { get; set; } 
        public int QuantityOfLessons { get; set; }
        public decimal Discount { get; set; } = decimal.One;
    }
}
