using CoursesWeb.Repositories.Contracts;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace CoursesWeb.Repositories
{
    public class StudentRepository : GenericRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(CoursesManagmentContext context) : base(context) { }

        public async Task<StudentEntity?> GetByEmailAsync(string email)
        {
            return await _context.Students.AsNoTracking()
                .Where(x => x.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<StudentEntity>> GetByNameAsync(string name)
        {
            return await _context.Students.AsNoTracking()
                .Where (x => x.Name == name)
                .ToListAsync();
        }

        public async Task<StudentEntity?> GetWithEnrollmentsAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Enrollments)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
