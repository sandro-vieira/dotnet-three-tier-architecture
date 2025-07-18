namespace DevIO.Business.Models.Validations.Documents;

internal sealed class LegalEntityValidation
{
    public const int DocumentLenght = 14;

    public static bool Validation(string document)
    {
        var documentNumbers = Utils.ExtractNumbers(document);

        if (!ValidLength(documentNumbers))
        {
            return false;
        }

        return !EqualDigits(documentNumbers) && ValidDigits(documentNumbers);
    }

    private static bool ValidLength(string document)
        => document.Length == DocumentLenght;

    private static bool EqualDigits(string document)
    {
        string[] invalidDocuments =
        {
            "00000000000000",
            "11111111111111",
            "22222222222222",
            "33333333333333",
            "44444444444444",
            "55555555555555",
            "66666666666666",
            "77777777777777",
            "88888888888888",
            "99999999999999"
        };

        return invalidDocuments.Contains(document);
    }

    private static bool ValidDigits(string document)
    {
        var numberWithOutChecker = document.Substring(0, DocumentLenght - 2);
        var digitChecker = new DigitChecker(numberWithOutChecker)
            .WithMultiplierRange(2, 11)
            .ReplaceWith("0", 10, 11);

        var firstDigit = digitChecker.Calculate();
        digitChecker.Add(firstDigit);

        var secondDigit = digitChecker.Calculate();

        return string.Concat(firstDigit, secondDigit) == document.Substring(DocumentLenght - 2, 3);
    }

}
