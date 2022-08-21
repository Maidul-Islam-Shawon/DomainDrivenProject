using GenericRepositoryEntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Models;
using System.Linq.Expressions;

#nullable disable

namespace GenericRepositoryEntityFramework.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        protected readonly DbContext Context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext context)
        {
            Context = context;
            if(context != null)
            {
                _dbSet = context.Set<TEntity>();
            }
        }

        

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> include)
        {
            IQueryable<TEntity> query = _dbSet.Include(include);
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id).ConfigureAwait(false);
        }

        public virtual async Task<QueryResult<TEntity>> GetOrderedPageQueryResultAsync(QueryObjectParams queryObjectParams,
            IQueryable<TEntity> query)
        {
            IQueryable<TEntity> OrderQuery = query;

            if(queryObjectParams.SortingParams != null && queryObjectParams.SortingParams.Count > 0)
            {
                //OrderQuery = SortingExtension
            }

            throw new NotImplementedException();
        }

        public Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams)
        {
            throw new NotImplementedException();
        }

        public Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams, List<Expression<Func<TEntity, object>>> includes)
        {
            throw new NotImplementedException();
        }

        public Task<QueryResult<TEntity>> GetPageAsync<TProperty>(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate, List<Expression<Func<TEntity, TProperty>>> includes = null)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public virtual async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }

        public virtual async Task Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
