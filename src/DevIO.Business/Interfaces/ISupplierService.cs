using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

public interface ISupplierService : IDisposable
{
    Task AddAsync(Supplier supplier, CancellationToken cancellationToken);
    Task UpdateAsync(Supplier supplier, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
