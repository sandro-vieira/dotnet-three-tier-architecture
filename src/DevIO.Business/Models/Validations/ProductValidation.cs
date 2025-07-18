using FluentValidation;

namespace DevIO.Business.Models.Validations;

public class ProductValidation : AbstractValidator<Product>
{
    public ProductValidation()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("The field {PropertyName} cannot be empty")
            .Length(2, 200).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters long");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("The field {PropertyName} cannot be empty")
            .Length(2, 1000).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters long");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("The field {PropertyName} must be greather than {ComparisonValue}");
    }
}
