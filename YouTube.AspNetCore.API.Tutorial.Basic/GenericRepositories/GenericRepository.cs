using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YouTube.AspNetCore.API.Tutorial.Basic.Context;

namespace YouTube.AspNetCore.API.Tutorial.Basic.GenericRepositories
{
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
   {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(TEntity entity)
        {
            try
            {
                 _dbSet.Update(entity);
                 await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(TEntity entity)
        {
            try
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<TEntity> GetAllList()
        {
            try
            {
                return _dbSet.AsNoTracking().AsQueryable();
            }
            catch
            {
                throw;
            }
        }
        public async Task<TEntity> GetEntityById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        } 
    }
}
