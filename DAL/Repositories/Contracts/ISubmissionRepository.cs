using DAL.Entities;

namespace CoursesWeb.Repositories.Contracts
{
    public interface ISubmissionRepository : IEnrollmentRepository<SubmissionEntity>
    {
        Task<IEnumerable<SubmissionEntity>> GetByAssignmentIdAsync(int id);
    }
}
