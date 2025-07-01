using CoursesWeb.Repositories.Contracts;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursesWeb.Repositories
{
    public class CourseRepository : GenericRepository<CourseEntity>, ICourseRepository
    {
        public CourseRepository(CoursesManagmentContext context) : base(context){ }

        public async Task<IEnumerable<CourseEntity?>> GetByLevelAsync(string level)
        {
            return await _context.Courses
                .Where(c => c.Level == level)
                .ToListAsync();
        }

        public async Task<IEnumerable<CourseEntity?>> GetByQuantityOfLessonsAsync(int quantity)
        {
            return await _context.Courses
                .Where(c => c.QuantityOfLessons == quantity)
                .ToListAsync();
        }

        public async Task<CourseEntity?> GetByTittleAsync(string tittle)
        {
            return await _context.Courses
                .Where(c => c.Title == tittle)
                .FirstOrDefaultAsync();
        }
    }
}
