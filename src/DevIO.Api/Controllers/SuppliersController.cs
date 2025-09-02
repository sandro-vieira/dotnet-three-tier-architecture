using DevIO.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers;

[Route("api/suppliers")]
public class SuppliersController : CustomController
{
    public SuppliersController()
    {

    }

    [HttpGet]
    public async Task<IEnumerable<SupplierViewModel>> GetAllAsync(CancellationToken cancellationToken)
    {

    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SupplierViewModel>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {

    }

    public async Task<ActionResult<SupplierViewModel>> AddAsync(SupplierViewModel supplierViewModel, CancellationToken cancellationToken)
    {

    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, SupplierViewModel supplierViewModel, CancellationToken cancellationToken)
    {

    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<SupplierViewModel>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {

    }
}
