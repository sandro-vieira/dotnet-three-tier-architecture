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

        await _supplierRepository.AddAsync(supplier, cancellationToken);
    }

    public async Task UpdateAsync(Supplier supplier, CancellationToken cancellationToken)
    {
        if (!ExecuteValidation(new SupplierValidation(), supplier))
        {
            return;
        }

        await _supplierRepository.UpdateAsync(supplier, cancellationToken);
    }
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken) => await _supplierRepository.DeleteAsync(id, cancellationToken);

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