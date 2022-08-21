using SharedKernel.Models;
using System.Linq.Expressions;

namespace GenericRepositoryEntityFramework.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> include);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams);
        Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams,
            Expression<Func<TEntity, bool>> predicate);
        Task<QueryResult<TEntity>> GetOrderedPageQueryResultAsync(QueryObjectParams queryObjectParams,
            IQueryable<TEntity> query);
        Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams,
            List<Expression<Func<TEntity, object>>> includes);
        Task<QueryResult<TEntity>> GetPageAsync<TProperty>(QueryObjectParams queryObjectParams,
            Expression<Func<TEntity, bool>> predicate, List<Expression<Func<TEntity, TProperty>>> includes = null);
    }
}
