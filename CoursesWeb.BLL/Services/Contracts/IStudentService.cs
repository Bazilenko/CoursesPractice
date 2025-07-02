

using CoursesWeb.DTOs.Request.Student;
using CoursesWeb.DTOs.Response;

namespace CoursesWeb.Services.Contracts
{
    public interface IStudentService
    {
        public interface IAttendanceService
        {
            Task<IEnumerable<StudentMiniResponseDTO>> GetAllAsync();
            Task<StudentMiniResponseDTO> GetByIdAsync(int id);
            Task<StudentMiniResponseDTO> CreateAsync(StudentCreateReqDTO dto, CancellationToken cancellationToken = default);
            Task<StudentMiniResponseDTO> UpdateAsync(int id, StudentUpdateReqDTO dto, CancellationToken cancellationToken = default);
            Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        }
    }
}
