using DAL.Entities;

namespace CoursesWeb.Repositories.Contracts
{
    public interface IAssignmentRepository : IGenericRepository<AssignmentEntity>

    {
        Task<IEnumerable<AssignmentEntity>> GetByLessonId(int id);
    }
}
