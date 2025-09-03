using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevIO.Api.Controllers;

[ApiController]
public abstract class CustomController : ControllerBase
{
    protected bool IsValidOperation() => true;

    protected ActionResult CustomResponse(object? result = null)
    {
        if (IsValidOperation())
        {
            return Ok(result);
        }
        return BadRequest(new
        {
            // Get Errors
        });
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
        {
            // Notify Errors 
        }

        return CustomResponse();
    }

    protected void NotifyError(string message)
    {
        // Notify Error
    }
}
