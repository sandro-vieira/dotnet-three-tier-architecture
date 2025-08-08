using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

public interface IProductService : IDisposable
{
    Task AddAsync(Product product, CancellationToken cancellationToken);
    Task UpdateAsync(Product product, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
