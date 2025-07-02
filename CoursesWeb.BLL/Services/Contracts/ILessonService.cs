using CoursesWeb.DTOs.Request.Lesson;
using CoursesWeb.DTOs.Request.Teacher;
using CoursesWeb.DTOs.Request.TeacherEntity;
using CoursesWeb.DTOs.Response;

namespace CoursesWeb.Services.Contracts
{
    public interface ILessonService
    {
        Task<IEnumerable<LessonMiniResponseDTO>> GetAllAsync();
        Task<LessonMiniResponseDTO> GetByIdAsync(int id);
        Task<LessonMiniResponseDTO> CreateAsync(LessonCreateReqDTO dto, CancellationToken cancellationToken = default);
        Task<LessonMiniResponseDTO> UpdateAsync(int id, LessonUpdateReqDTO dto, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
