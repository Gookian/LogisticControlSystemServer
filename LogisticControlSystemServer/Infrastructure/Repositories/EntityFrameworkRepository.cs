using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using LogisticControlSystemServer.Infrastructure.Interfaces;

namespace LogisticControlSystemServer.Infrastructure.Repositories
{
    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        private DbSet<TEntity> _dbSet;

        public EntityFrameworkRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public TEntity? FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TEntity Update(int id, TEntity entity)
        {
            var entry = _dbSet.Find(id);
            _context.Entry(entry).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}