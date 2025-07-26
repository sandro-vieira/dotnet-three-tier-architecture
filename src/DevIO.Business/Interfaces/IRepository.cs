using System.Linq.Expressions;
using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken );
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
}
