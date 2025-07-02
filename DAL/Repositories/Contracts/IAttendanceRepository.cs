using DAL.Entities;

namespace CoursesWeb.Repositories.Contracts
{
    public interface IAttendanceRepository : IEnrollmentRepository<AttendanceEntity>
    {
        Task<IEnumerable<AttendanceEntity>> GetByLessonIdAsync(int id);
    }
}
