using System.Text;

namespace DevIO.Business.Models.Validations.Documents;

internal sealed class Utils
{
    public static string ExtractNumbers(string numbers)
    {
        var onlyNumbers = new StringBuilder();
        foreach (var number in numbers)
        {
            if (char.IsDigit(number))
            {
                onlyNumbers.Append(number);
            }
        }

        return onlyNumbers.ToString().Trim();
    }
}

