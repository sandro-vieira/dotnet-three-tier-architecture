using System.Net;
using DevIO.Business.Interfaces;
using DevIO.Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevIO.Api.Controllers;

[ApiController]
public abstract class CustomController : ControllerBase
{
    private readonly INotificator _notificator;

    protected CustomController(INotificator notificator)
        => _notificator = notificator;

    protected bool IsValidOperation()
        => !_notificator.HasNotifications();

    protected ActionResult CustomResponse(HttpStatusCode httpStatusCode, object? result = null)
    {
        if (IsValidOperation())
        {
            return new ObjectResult(result)
            {
                StatusCode = (int)httpStatusCode
            };
        }
        return BadRequest(new
        {
            errors = _notificator.GetNotifications().Select(n => n.Message)
        });
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
        {
            NotifyInvalidModelErrors(modelState);
        }

        return CustomResponse(HttpStatusCode.OK);
    }

    protected void NotifyInvalidModelErrors(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(e => e.Errors);
        foreach (var error in errors)
        {
            var errorMessage = error.Exception == null
                ? error.ErrorMessage
                : error.Exception.Message;

            NotifyError(errorMessage);
        }
    }

    protected void NotifyError(string message)
        => _notificator.Handle(new Notification(message));
}
