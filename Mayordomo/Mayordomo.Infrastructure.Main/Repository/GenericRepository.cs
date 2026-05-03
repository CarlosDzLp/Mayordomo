using Mayordomo.Infrastructure.Persistence.Context;
using Mayordomo.Infrastructure.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mayordomo.Infrastructure.Main.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Constructor
        protected readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
            this.dbSet = context.Set<T>();
        }
        #endregion

        #region Methods
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            var set = await _context.Set<T>().AddAsync(entity, cancellationToken);
            int saved = await SaveCommitAsync(cancellationToken);
            return (saved > 0) ? set.Entity : null;
        }

        public async Task<int> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddRangeAsync(entities, cancellationToken);
            return await SaveCommitAsync(cancellationToken);
        }

        public async Task<T> FindAsync(CancellationToken cancellationToken = default, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
            IQueryable<T> query = dbSet;
            if (include != null)
            {
                query = include(query);
            }
            if (orderBy != null)
            {
                if (filter != null)
                {
                    var result = await orderBy(query).FirstOrDefaultAsync(filter, cancellationToken);
                    return result!;
                }
                else
                {
                    var result = await orderBy(query).FirstOrDefaultAsync(cancellationToken);
                    return result!;
                }
            }
            else
            {
                if (filter != null)
                {
                    var result = await query.FirstOrDefaultAsync(filter, cancellationToken);
                    return result!;
                }
                else
                {
                    var result = await query.FirstOrDefaultAsync(cancellationToken);
                    return result!;
                }
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
            IQueryable<T> query = dbSet;

            if (include != null)
            {
                query = include(query);
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync(cancellationToken);
            }
            else
            {
                return await query.ToListAsync(cancellationToken);
            }
        }

        public async Task<T> RemoveAsync(T entity, CancellationToken cancellationToken = default)
        {
            var result = _context.Set<T>().Remove(entity);
            int saved = await SaveCommitAsync(cancellationToken);
            return (saved > 0) ? result.Entity : null;
        }

        public async Task<int> RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().RemoveRange(entities);
            return await SaveCommitAsync(cancellationToken);
        }

        private async Task<int> SaveCommitAsync(CancellationToken cancellationToken = default)
        {
            using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var saved = await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return saved;
            }
            catch (DbUpdateException)
            {
                await transaction.RollbackAsync();
                return 0;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return 0;
            }
        }

        public async Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Update(entity);
            return await SaveCommitAsync(cancellationToken);
        }
        #endregion
    }
}
