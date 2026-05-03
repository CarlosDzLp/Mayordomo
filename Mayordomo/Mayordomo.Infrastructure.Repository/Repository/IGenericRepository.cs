using System.Linq.Expressions;

namespace Mayordomo.Infrastructure.Repository.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IQueryable<T>>? include = null);
        Task<T> FindAsync(CancellationToken cancellationToken = default, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IQueryable<T>>? include = null);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<int> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task<T> RemoveAsync(T entity, CancellationToken cancellationToken = default);
        Task<int> RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    }
}
