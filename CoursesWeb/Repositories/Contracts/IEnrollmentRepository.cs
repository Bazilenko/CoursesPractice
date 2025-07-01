using DAL.Entities;

namespace CoursesWeb.Repositories.Contracts
{
    public interface IEnrollmentRepository : IGenericRepository<EnrollmentEntity>
    {
        Task<IEnumerable<EnrollmentEntity>> GetByStudentIdAsync(int id);
    }
}
