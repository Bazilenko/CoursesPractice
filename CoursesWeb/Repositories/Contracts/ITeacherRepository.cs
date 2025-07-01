using DAL.Entities;

namespace CoursesWeb.Repositories.Contracts
{
    public interface ITeacherRepository : IEnrollmentRepository<TeacherEntity>
    {
        Task<IEnumerable<TeacherEntity?>> GetByNationality(string nationality);
        Task<TeacherEntity?> GetByEmail(string email);
        Task<IEnumerable<TeacherEntity?>> GetByLastNameAsync(string lastName);
        Task<TeacherEntity?> GetWithLessonsAsync(int id);
    }
}
