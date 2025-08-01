using DevIO.Business.Models;
using FluentValidation;

namespace DevIO.Business.Services;

public abstract class BaseService
{
    protected void Notify(string message)
    {
        // Method intentionally left empty.
    }

    protected static bool ExecuteValidation<TValidator, TEntity>(TValidator validation, TEntity entity) 
        where TValidator : AbstractValidator<TEntity>
        where TEntity : Entity
    {
        var result = validation.Validate(entity);

        if (result.IsValid)
        {
            return true;
        }

        foreach (var error in result.Errors)
        {
            Console.WriteLine($"Property: {error.PropertyName}, Error: {error.ErrorMessage}");
        }
        return false;
    }
}
