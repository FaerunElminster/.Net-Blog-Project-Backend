using Core.Entities;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Abstracts
{
    public interface IRepository<TEntity>
    where TEntity : class, IBaseEntity, new()
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        IList<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null);
        IQueryable<TEntity> Queryable();
        IQueryable<TEntity> ExecuteRawSql(string sql, params object[] sqlParams);
    }
}
