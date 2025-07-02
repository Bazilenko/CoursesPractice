using DAL.Entities;

namespace CoursesWeb.Repositories.Contracts
{
    public interface ILessonRepository : IEnrollmentRepository<LessonEntity>
    {
        Task<IEnumerable<LessonEntity>> GetByCourseIdAsync(int id);
        Task<LessonEntity?> GetByTittleAsync(string tittle);
    }
}
