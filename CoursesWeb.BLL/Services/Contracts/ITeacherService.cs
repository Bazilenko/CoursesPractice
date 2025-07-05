using CoursesWeb.DTOs.Request.Teacher;
using CoursesWeb.DTOs.Request.TeacherEntity;
using CoursesWeb.DTOs.Response;
using DAL.Entities;

namespace CoursesWeb.Services.Contracts
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherMiniResponseDTO>> GetAllAsync();
        Task<TeacherCreateReqDTO> GetByIdAsync(int id);
        Task<TeacherCreateReqDTO> CreateAsync(TeacherCreateReqDTO dto, CancellationToken cancellationToken = default);
        Task<TeacherMiniResponseDTO> UpdateAsync(int id, TeacherUpdateReqDTO dto, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
