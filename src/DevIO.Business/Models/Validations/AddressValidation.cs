using FluentValidation;

namespace DevIO.Business.Models.Validations;

public class AddressValidation : AbstractValidator<Address>
{
    public AddressValidation()
    {
        RuleFor(a => a.Street)
            .NotEmpty().WithMessage("The field {PropertyName} cannot be empty")
            .Length(2, 200).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters long");

        RuleFor(a => a.Number)
            .NotEmpty().WithMessage("The field {PropertyName} cannot be empty")
            .Length(1, 50).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters long");

        RuleFor(a => a.AdditionalInfo)
            .Length(2, 250).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters long");

        RuleFor(a => a.PostalCode)
            .NotEmpty().WithMessage("The field {PropertyName} cannot be empty")
            .Length(8).WithMessage("The field {PropertyName} must have {MaxLength} characters");

        RuleFor(a => a.District)
            .NotEmpty().WithMessage("The field {PropertyName} cannot be empty")
            .Length(2, 100).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters long");

        RuleFor(a => a.City)
            .NotEmpty().WithMessage("The field {PropertyName} cannot be empty")
            .Length(2, 100).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters long");

        RuleFor(a => a.State)
            .NotEmpty().WithMessage("The field {PropertyName} cannot be empty")
            .Length(2, 50).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters long");
    }
}
