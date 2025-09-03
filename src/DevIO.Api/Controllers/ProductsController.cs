using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers;

[Route("api/products")]
public class ProductsController : CustomController
{
    private readonly IProductRepository _productRepository;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(
        IProductRepository productRepository,
        IProductService productService,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductViewModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var collection = await _productRepository.GetProductsSuppliersAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ProductViewModel>>(collection);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var productViewModel = await GetProductAsync(id, cancellationToken);

        if (productViewModel == null)
        {
            return NotFound();
        }

        return productViewModel;
    }

    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> AddAsync(ProductViewModel productViewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponse(ModelState);
        }

        await _productService.AddAsync(_mapper.Map<Product>(productViewModel), cancellationToken);

        return CustomResponse(productViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, ProductViewModel productViewModel, CancellationToken cancellationToken)
    {
        if (id != productViewModel.Id)
        {
            NotifyError("The provided id does not match the product id.");
            return CustomResponse();
        }

        if (!ModelState.IsValid)
        {
            return CustomResponse(ModelState);
        }

        var existingProduct = await GetProductAsync(id, cancellationToken);

        if (existingProduct == null)
        {
            return NotFound();
        }

        existingProduct.SupplierId = productViewModel.SupplierId;
        existingProduct.Name = productViewModel.Name;
        existingProduct.Description = productViewModel.Description;
        existingProduct.Price = productViewModel.Price;
        existingProduct.IsActive = productViewModel.IsActive;

        await _productService.UpdateAsync(_mapper.Map<Product>(existingProduct), cancellationToken);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingProduct = await GetProductAsync(id, cancellationToken);
        if (existingProduct == null)
        {
            return NotFound();
        }

        await _productService.DeleteAsync(id, cancellationToken);

        return CustomResponse();
    }

    private async Task<ProductViewModel> GetProductAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductSupplierAsync(id, cancellationToken);
        return _mapper.Map<ProductViewModel>(product);
    }
}
