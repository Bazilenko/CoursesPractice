using DAL.Entities;

namespace CoursesWeb.Repositories.Contracts
{
    public interface ISubmissionRepository : IGenericRepository<SubmissionEntity>
    {
        Task<IEnumerable<SubmissionEntity>> GetByAssignmentIdAsync(int id);
    }
}
