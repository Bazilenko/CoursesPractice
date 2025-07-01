using DAL.Entities;

namespace CoursesWeb.Repositories.Contracts
{
    public interface IStudentRepository : IGenericRepository<StudentEntity>
    {
        Task<StudentEntity> GetByEmailAsync(string email);
        Task<IEnumerable<StudentEntity>> GetByNameAsync(string name);
    }
}
