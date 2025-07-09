using System.Linq.Expressions;

namespace YouTube.AspNetCore.API.Tutorial.Basic.GenericRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        IQueryable<TEntity> GetAllList();
        Task<TEntity> GetEntityById(int id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
