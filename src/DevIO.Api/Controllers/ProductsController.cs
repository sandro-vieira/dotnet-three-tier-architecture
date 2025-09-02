using DevIO.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers;

[Route("api/products")]
public class ProductsController : CustomController
{
    public ProductsController()
    {
      
    }

    [HttpGet]
    public async Task<IEnumerable<ProductViewModel>> GetAllAsync(CancellationToken cancellationToken)
    {

    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {

    }

    public async Task<ActionResult<ProductViewModel>> AddAsync(ProductViewModel productViewModel, CancellationToken cancellationToken)
    {

    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, ProductViewModel productViewModel, CancellationToken cancellationToken)
    {

    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {

    }
}
