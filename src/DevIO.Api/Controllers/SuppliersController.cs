using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers;

[Route("api/suppliers")]
public class SuppliersController : CustomController
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly ISupplierService _supplierService;
    private readonly IMapper _mapper;

    public SuppliersController(
        ISupplierRepository supplierRepository,
        ISupplierService supplierService,
        IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _supplierService = supplierService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<SupplierViewModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var collection = await _supplierRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SupplierViewModel>>(collection);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SupplierViewModel>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var supplierViewModel = await GetSupplierProductsAddressAsync(id, cancellationToken);

        if (supplierViewModel == null)
        {
            return NotFound();
        }

        return supplierViewModel;
    }

    [HttpPost]
    public async Task<ActionResult<SupplierViewModel>> AddAsync(SupplierViewModel supplierViewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponse(ModelState);
        }

        await _supplierService.AddAsync(_mapper.Map<Supplier>(supplierViewModel), cancellationToken);

        return CustomResponse(supplierViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, SupplierViewModel supplierViewModel, CancellationToken cancellationToken)
    {
        if (id != supplierViewModel.Id)
        {
            NotifyError("The provided id does not match the supplier id.");
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return CustomResponse(ModelState);
        }

        var existingSupplier = await GetSupplierProductsAddressAsync(id, cancellationToken);

        if (existingSupplier == null)
        {
            return NotFound();
        }

        existingSupplier.Name = supplierViewModel.Name;
        existingSupplier.Document = supplierViewModel.Document;
        existingSupplier.SupplierType = supplierViewModel.SupplierType;
        existingSupplier.IsActive = supplierViewModel.IsActive;
        existingSupplier.Address = supplierViewModel.Address;
        existingSupplier.Products = supplierViewModel.Products;
        existingSupplier.Id = supplierViewModel.Id;
        existingSupplier.Address.Id = supplierViewModel.Address.Id;
        existingSupplier.Address.SupplierId = supplierViewModel.Id;
        existingSupplier.Products = supplierViewModel.Products;
        existingSupplier.Products.ToList().ForEach(p => p.SupplierId = supplierViewModel.Id);

        await _supplierService.UpdateAsync(_mapper.Map<Supplier>(existingSupplier), cancellationToken);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<SupplierViewModel>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingSupplier = await GetSupplierProductsAddressAsync(id, cancellationToken);
        if (existingSupplier == null)
        {
            return NotFound();
        }

        await _supplierService.DeleteAsync(id, cancellationToken);

        return CustomResponse();
    }

    private async Task<SupplierViewModel> GetSupplierProductsAddressAsync(Guid id, CancellationToken cancellationToken)
    {
        var supplier = await _supplierRepository.GetSupplierProductsAddressAsync(id, cancellationToken);
        return _mapper.Map<SupplierViewModel>(supplier);
    }
}
