using CoursesWeb.Repositories.Contracts;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace CoursesWeb.Repositories
{
    public class AssignmentRepository : GenericRepository<AssignmentEntity>, IAssignmentRepository
    {
        public AssignmentRepository(CoursesManagmentContext context) : base(context) { }

        public async Task<IEnumerable<AssignmentEntity>> GetByLessonId(int id)
        {
            return await _context.Assignment
                .Where(a => a.LessonId == id)
                .ToListAsync();
        }
    }
}
