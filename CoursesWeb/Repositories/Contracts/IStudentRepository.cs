using DAL.Entities;

namespace CoursesWeb.Repositories.Contracts
{
    public interface IStudentRepository : IEnrollmentRepository<StudentEntity>
    {
        Task<StudentEntity> GetByEmailAsync(string email);
        Task<IEnumerable<StudentEntity>> GetByNameAsync(string name);
        Task<StudentEntity?> GetWithEnrollmentsAsync(int id);
    }
}
