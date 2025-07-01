using CoursesWeb.Repositories.Contracts;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace CoursesWeb.Repositories
{
    using Microsoft.EntityFrameworkCore;
    public abstract class GenericRepository<TEntity> : IEnrollmentRepository<TEntity> where TEntity : class
    {
        protected readonly CoursesManagmentContext _context;
        protected readonly DbSet<TEntity> table;
        public GenericRepository(CoursesManagmentContext context)
        {
            _context = context;
            table = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity) + " can't be null!");
            }
            var entityForAdding = await table.AddAsync(entity);
            return entityForAdding.Entity;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await table.AddAsync(entity);
            return entity;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            if(entity == null) 
                throw new ArgumentNullException(nameof(entity) + " can't be null!");
            await Task.Run(() => table.Remove(entity));

        }

        public virtual async Task DeleteByIdAsync(int Id)
        {
            var entity = await GetByIdAsync(Id);
            if (entity != null) 
                await Task.Run(() => table.Remove(entity));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await table.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int Id)
        {
            return await table.FindAsync(Id);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if(entity == null)
            throw new ArgumentNullException(nameof(entity) + " can't be null!");
            await Task.Run(() => table.Update(entity));
        }
    }
}
