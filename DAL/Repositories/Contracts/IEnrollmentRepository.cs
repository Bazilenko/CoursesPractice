using DAL.Entities;

namespace CoursesWeb.Repositories.Contracts
{
    public interface IEnrollmentRepository : IEnrollmentRepository<EnrollmentEntity>
    {
        Task<IEnumerable<EnrollmentEntity>> GetByStudentIdAsync(int id);
    }
}
