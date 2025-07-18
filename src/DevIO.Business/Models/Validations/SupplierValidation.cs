using DevIO.Business.Models.Validations.Documents;
using FluentValidation;

namespace DevIO.Business.Models.Validations;

public class SupplierValidation : AbstractValidator<Supplier>
{
    public SupplierValidation()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("The field {PropertyName} cannot be empty")
            .Length(2, 100).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters long");

        When(s => s.SupplierType == SupplierType.Undefined, () =>
        {
            RuleFor(s => s.SupplierType).NotEqual(SupplierType.Undefined)
                .WithMessage("The Supplier Type must be Individual or Legal Entity");
        });

        When(s => s.SupplierType == SupplierType.Individual, () =>
        {
            RuleFor(s => s.Document.Length).Equal(IndividualsValidation.DocumentLenght)
                .WithMessage("The field Document length is {ComparasionValue}. Expected length is {PropertyValue}");

            RuleFor(s => IndividualsValidation.Validation(s.Document)).Equal(true)
                .WithMessage("Document is invalid");
        });

        When(s => s.SupplierType == SupplierType.LegalEntity, () =>
        {
            RuleFor(s => s.Document.Length).Equal(LegalEntityValidation.DocumentLenght)
                .WithMessage("The field Document length is {ComparasionValue}. Expected length is {PropertyValue}");


            RuleFor(s => LegalEntityValidation.Validation(s.Document)).Equal(true)
                .WithMessage("Document is invalid");
        });

    }
}
