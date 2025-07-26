using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsBySupplierAsync(Guid supplierId, CancellationToken cancellationToken);
    Task<IEnumerable<Product>> GetProductsSuppliersAsync(CancellationToken cancellationToken);
    Task<Product> GetProductSupplierAsync(Guid id, CancellationToken cancellationToken);
}
