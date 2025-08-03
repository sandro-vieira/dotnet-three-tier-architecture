using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace DevIO.Business.Services;

public abstract class BaseService
{
    private readonly INotificator _notificator;

    protected BaseService(INotificator notificator) => _notificator = notificator;

    protected void Notify(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Notify(error.ErrorMessage);
        }
    }

    protected void Notify(string message) => _notificator.Handle(new Notification(message));

    protected bool ExecuteValidation<TValidator, TEntity>(TValidator validation, TEntity entity)
        where TValidator : AbstractValidator<TEntity>
        where TEntity : Entity
    {
        var result = validation.Validate(entity);

        if (result.IsValid)
        {
            return true;
        }

        Notify(result);

        return false;
    }
}
