using Microsoft.EntityFrameworkCore;
namespace CoursesWeb.Repositories.Contracts
{
    public interface IEnrollmentRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int Id);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteByIdAsync(int Id);
        Task<TEntity> CreateAsync(TEntity entity);
    }
}
