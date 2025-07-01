using CoursesWeb.Repositories.Contracts;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursesWeb.Repositories
{
    public class SubmissionRepository : GenericRepository<SubmissionEntity>, ISubmissionRepository
    {
        public SubmissionRepository(CoursesManagmentContext context) : base(context) { }

        public async Task<IEnumerable<SubmissionEntity>> GetByAssignmentIdAsync(int id)
        {
            return await _context.Submissions
                .Where(s => s.AssignmentId == id)
                .ToListAsync();
        }
    }
}
