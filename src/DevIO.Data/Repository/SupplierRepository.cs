using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository;

public class SupplierRepository : Repository<Supplier>, ISupplierRepository
{
    public SupplierRepository(CustomDbContext context) : base(context)
    {
    }

    public async Task<Supplier> GetSupplierAddressAsync(Guid id, CancellationToken cancellationToken)
        => await _db.Suppliers.AsNoTracking()
            .Include(a => a.Address)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

    public async Task<Supplier> GetSupplierProductsAddressAsync(Guid id, CancellationToken cancellationToken)
        => await _db.Suppliers.AsNoTracking()
            .Include(s => s.Products)
            .Include(s => s.Address)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

    public async Task<Address> GetAddressBySupplierAsync(Guid supplierId, CancellationToken cancellationToken)
        => await _db.Addresses.AsNoTracking()
            .FirstOrDefaultAsync(s => s.SupplierId == supplierId, cancellationToken);

    public async Task DeleteAddressAsync(Address address, CancellationToken cancellationToken)
    {
        _db.Addresses.Remove(address);
        await SaveChangesAsync(cancellationToken);
    }
}
