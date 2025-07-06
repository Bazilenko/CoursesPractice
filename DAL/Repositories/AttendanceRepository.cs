using CoursesWeb.Repositories.Contracts;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace CoursesWeb.Repositories
{
    public class AttendanceRepository : GenericRepository<AttendanceEntity>, IAttendanceRepository
        {
            public AttendanceRepository(CoursesManagmentContext context) : base(context) { }

       

        public async Task<IEnumerable<AttendanceEntity>> GetAttendanceWithStudentsByStudentIdAsync(int id)
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Lesson)
                .Where(a => a.StudentId == id)
                .ToListAsync();
        }
    }
}
