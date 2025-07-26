using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

public interface ISupplierRepository : IRepository<Supplier>
{
    Task<Supplier> GetSupplierAddressAsync(Guid id, CancellationToken cancellationToken);
    Task<Supplier> GetSupplierProductsAddressAsync(Guid id, CancellationToken cancellationToken);
    Task<Address> GetAddressBySupplierAsync(Guid supplierId, CancellationToken cancellationToken);
}
