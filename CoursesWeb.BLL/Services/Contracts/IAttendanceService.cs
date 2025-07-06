using CoursesWeb.BLL.DTOs.Response;
using CoursesWeb.DTOs.Request.Attendance;
using CoursesWeb.DTOs.Response;

namespace CoursesWeb.Services.Contracts
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceWithStudentResponseDTO>> GetByStudentIdAsync(int studentId);

      
    }
}
