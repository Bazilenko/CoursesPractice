using CoursesWeb.DTOs.Request.Course;
using CoursesWeb.DTOs.Request.Lesson;
using CoursesWeb.DTOs.Response;

namespace CoursesWeb.Services.Contracts
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseFullResponseDTO>> GetAllAsync();
        Task<CourseFullResponseDTO> GetByIdAsync(int id);
        Task<CourseFullResponseDTO> CreateAsync(CreateCourseReqDTO dto, CancellationToken cancellationToken = default);
        Task<CourseFullResponseDTO> UpdateAsync(int id, CourseUpdateReqDTO dto, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
