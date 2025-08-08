using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services;

public class ProductService : BaseService, IProductService
{
    private readonly IProductRepository _productRepository;
    private bool _disposed;

    public ProductService(IProductRepository productRepository, INotificator notificator)
        : base(notificator) => _productRepository = productRepository;

    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        if (!ExecuteValidation(new ProductValidation(), product))
        {
            return;
        }

        await _productRepository.AddAsync(product, cancellationToken);
    }
    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        if (!ExecuteValidation(new ProductValidation(), product))
        {
            return;
        }

        await _productRepository.UpdateAsync(product, cancellationToken);
    }
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken) => await _productRepository.DeleteAsync(id, cancellationToken);

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _productRepository?.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~ProductService() => Dispose(false);
}
