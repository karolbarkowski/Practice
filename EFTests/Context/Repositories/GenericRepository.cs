using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Context.Repositories
{
    /// <summary>
    /// Note about this repo - it assumes that it's used in a disconnected scenarios, like api or mvc controllers where context get disposed quickly
    /// and there's no need to track entities state. That's why it's using the "AsNoTracking" method for queries. Returned entities will NOT be tracked
    /// and no state data will be stored or cached.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DbContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> All()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> results = _dbSet.AsNoTracking().Where(predicate).ToList();
            return results;
        }

        public TEntity FindByKey(int id)
        {
            //we could use this in here:
            //_dbSet.Find(id);
            //but Find method on db set first checks against the cache if there's already an eneity being tracked in there
            //and this repository is assuming a disconnected scenariu so no cache is needed and we'd like to get use of
            //AsNoTracking as in other queries. That's why we do this:
            var item = Expression.Parameter(typeof(TEntity), "entity");
            var prop = Expression.Property(item, typeof(TEntity).Name + "Id");
            var value = Expression.Constant(id);
            var equal = Expression.Equal(prop, value);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);

            return _dbSet.AsNoTracking().SingleOrDefault(lambda);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
