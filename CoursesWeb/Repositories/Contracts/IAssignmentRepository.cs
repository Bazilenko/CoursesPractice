using DAL.Entities;

namespace CoursesWeb.Repositories.Contracts
{
    public interface IAssignmentRepository : IEnrollmentRepository<AssignmentEntity>

    {
        Task<IEnumerable<AssignmentEntity>> GetByLessonId(int id);
    }
}
