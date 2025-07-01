using CoursesWeb.Repositories.Contracts;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursesWeb.Repositories
{
    public class TeacherRepository : GenericRepository<TeacherEntity>, ITeacherRepository
    {
        public TeacherRepository(CoursesManagmentContext context) : base(context) { }

        public async Task<TeacherEntity?> GetByEmail(string email)
        {
            return await _context.Teachers
                .Where(x => x.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TeacherEntity?>> GetByLastNameAsync(string lastName)
        {
            return await _context.Teachers
                .Where(x => x.LastName == lastName)
                .ToListAsync();
        }

        public async Task<IEnumerable<TeacherEntity?>> GetByNationality(string nationality)
        {
            return await _context.Teachers
                .Where(t => t.Nationality == nationality)
                .ToListAsync();
        }

        public async Task<TeacherEntity?> GetWithLessonsAsync(int id)
        {
            return await _context.Teachers
                .Include(t => t.Lessons)
                .FirstOrDefaultAsync();
        }
    }
}
