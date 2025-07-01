namespace CoursesWeb.Repositories.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetByIdAsync(int Id);
        Task<IEnumerable<TEntity>> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteByIdAsync(int Id);
        Task<TEntity> CreateAsync(TEntity entity);
    }
}
