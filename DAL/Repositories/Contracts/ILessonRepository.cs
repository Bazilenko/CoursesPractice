using DAL.Entities;

namespace CoursesWeb.Repositories.Contracts
{
    public interface ILessonRepository : IGenericRepository<LessonEntity>
    {
        Task<IEnumerable<LessonEntity>> GetByCourseIdAsync(int id);
        Task<LessonEntity?> GetByTittleAsync(string tittle);
    }
}
