using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services;

public class SupplierService : BaseService, ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private bool _disposed;

    public SupplierService(ISupplierRepository supplierRepository)
        => _supplierRepository = supplierRepository;

    public async Task AddAsync(Supplier supplier, CancellationToken cancellationToken)
    { 
        if (!ExecuteValidation(new SupplierValidation(), supplier)
            || !ExecuteValidation(new AddressValidation(), supplier.Address))
        {
            return;
        }

        var supplierExists = await _supplierRepository.FindAsync(s => s.Document == supplier.Document, cancellationToken);
        if (supplierExists.Any())
        {
            Notify("There is a supplier with this document number.");
            return;
        }

        await _supplierRepository.AddAsync(supplier, cancellationToken);
    }

    public async Task UpdateAsync(Supplier supplier, CancellationToken cancellationToken)
    {
        if (!ExecuteValidation(new SupplierValidation(), supplier))
        {
            return;
        }

        var supplierExists = await _supplierRepository.FindAsync(s => 
            s.Document == supplier.Document 
            && s.Id != supplier.Id,
            cancellationToken);
        if (supplierExists.Any())
        {
            Notify("There is a supplier with this document number.");
            return;
        }

        await _supplierRepository.UpdateAsync(supplier, cancellationToken);
    }
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var supplier = await _supplierRepository.GetSupplierProductsAddressAsync(id, cancellationToken);
        
        if (supplier == null)
        {
            Notify("Supplier not found.");
            return;
        }

        if (supplier.Products.Any())
        {
            Notify("Supplier has registered products.");
            return;
        }

        if (supplier.Address != null)
        {
            await _supplierRepository.DeleteAddressAsync(supplier.Address, cancellationToken);
        }

        await _supplierRepository.DeleteAsync(id, cancellationToken);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _supplierRepository?.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~SupplierService() => Dispose(false);
}