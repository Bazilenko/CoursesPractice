using CoursesWeb.Repositories.Contracts;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursesWeb.Repositories
{
    public class LessonRepository : GenericRepository<LessonEntity>, ILessonRepository
    {
        public LessonRepository(CoursesManagmentContext context) : base(context) { }
        public async Task<IEnumerable<LessonEntity>> GetByCourseIdAsync(int id)
        {
            return await _context.Lessons
                .Where(l => l.CourseId == id)
                .ToListAsync();
        }

        public async Task<LessonEntity?> GetByTittleAsync(string tittle)
        {
            return await _context.Lessons
                .Where(l => l.Tittle == tittle)
                .FirstOrDefaultAsync();
        }
    }
}
