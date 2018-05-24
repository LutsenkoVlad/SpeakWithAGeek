using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Geek.Infrastructure.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> GetAll() => _dbSet;

        public IQueryable<TEntity> GetAllAsQueryable() => _dbSet.AsQueryable();

        public TEntity GetById(int id) => _dbSet.Find(id);

        public IEnumerable<TEntity> GetMany(Func<TEntity, bool> predicate) => _dbSet.Where(predicate);

        public IQueryable<TEntity> GetManyAsQueryable(Expression<Func<TEntity, bool>> predicate) => _dbSet.Where(predicate);

        public void Remove(TEntity entity) => _dbSet.Remove(entity);

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public void SaveChanges() => _dbContext.SaveChanges();

        public async Task<TEntity> GetByGuidAsync(Guid guid) => await _dbSet.FindAsync(guid);
    }

    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        IQueryable<TEntity> GetManyAsQueryable(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAllAsQueryable();
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        Task SaveChangesAsync();
        void SaveChanges();
        Task<TEntity> GetByGuidAsync(Guid id);
    }
}
