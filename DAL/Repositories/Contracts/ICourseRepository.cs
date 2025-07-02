using DAL.Entities;

namespace CoursesWeb.Repositories.Contracts
{
    public interface ICourseRepository : IEnrollmentRepository<CourseEntity>
    {
        Task<CourseEntity?> GetByTittleAsync(string tittle);
        Task<IEnumerable<CourseEntity?>> GetByLevelAsync(string level);
        Task<IEnumerable<CourseEntity?>> GetByQuantityOfLessonsAsync(int quantity);

    }
}
