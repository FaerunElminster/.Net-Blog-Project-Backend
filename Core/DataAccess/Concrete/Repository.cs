using Core.Entities;
using DataAccess.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Concretes
{
    public abstract class Repository<TEntity, TDBContext> : IRepository<TEntity>, IDisposable, IAsyncDisposable
    where TDBContext : DbContext, new()
    where TEntity : class, IBaseEntity, new()
    {
        private DbContext _context;
        private bool disposedValue;

        public Repository() => _context = new TDBContext();

        public void Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public async Task AddAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        //public void GetUserWithBlog(Guid userId)
        //{
        //    using (SqlConnection sqlConnection1 = new SqlConnection("Server = ISTN35483\\MSSQLSERVERR; Trusted_Connection = True; TrustServerCertificate = True; Database = NttBlog"))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            Int32 rowsAffected;

        //            cmd.CommandText = "usp_GetUserWithBlog";
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Connection = sqlConnection1;

        //            sqlConnection1.Open();

        //            rowsAffected = cmd.ExecuteNonQuery();

        //        }
        //    }
        //}

        public IQueryable<TEntity> ExecuteRawSql(string sql, params object[] sqlParams)
        {
            using (var context = new TDBContext())
            {
                return context.Database.SqlQueryRaw<TEntity>(sql, sqlParams);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TDBContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
            => filter != null ? _context.Set<TEntity>().Where(filter).ToList() : _context.Set<TEntity>().ToList();

        public IQueryable<TEntity> Queryable()
            => _context.Set<TEntity>().AsQueryable();

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
#endregion