using CoursesWeb.DTOs.Request.Attendance;
using CoursesWeb.DTOs.Response;

namespace CoursesWeb.Services.Contracts
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceFullResponseDTO>> GetAllAsync();
        Task<AttendanceFullResponseDTO> GetByIdAsync(int id);
        Task<AttendanceFullResponseDTO> CreateAsync(AttendanceCreateReqDTO dto, CancellationToken cancellationToken = default);
        Task<AttendanceFullResponseDTO> UpdateAsync(int id, AttendanceUpdateReqDTO dto, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
