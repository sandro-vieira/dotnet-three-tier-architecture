using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(CustomDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetProductsBySupplierAsync(Guid supplierId, CancellationToken cancellationToken)
        => await FindAsync(p => p.SupplierId == supplierId, cancellationToken);

    public async Task<IEnumerable<Product>> GetProductsSuppliersAsync(CancellationToken cancellationToken)
        => await _db.Products.AsNoTracking()
            .Include(s => s.Supplier)
            .OrderBy(p => p.Name).ToListAsync(cancellationToken);

    public async Task<Product> GetProductSupplierAsync(Guid id, CancellationToken cancellationToken)
        => await _db.Products.AsNoTracking()
            .Include(s => s.Supplier)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
}
