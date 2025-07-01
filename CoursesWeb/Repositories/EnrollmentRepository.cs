using CoursesWeb.Repositories.Contracts;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursesWeb.Repositories
{
    public class EnrollmentRepository :  GenericRepository<EnrollmentEntity>, IEnrollmentRepository
    {
        public EnrollmentRepository(CoursesManagmentContext dbContext) : base(dbContext){ }

        public async Task<IEnumerable<EnrollmentEntity>> GetByStudentIdAsync(int id)
        {
            return await _context.Enrollments
                .Where(e => e.StudentId == id)
                .ToListAsync();
        }
    }
}
