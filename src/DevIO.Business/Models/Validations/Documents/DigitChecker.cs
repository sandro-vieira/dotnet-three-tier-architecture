namespace DevIO.Business.Models.Validations.Documents;

internal sealed class DigitChecker
{
    private string _numbers;
    private const int Module = 11;
    private readonly List<int> _multipliers = [2, 3, 4, 5, 6, 7, 8, 9];
    private readonly Dictionary<int, string> _substitutions = [];
    private readonly bool _moduleComplement = true;

    public DigitChecker(string numbers) => _numbers = numbers;

    public DigitChecker WithMultiplierRange(int firstMultiplier, int lastMultiplier)
    {
        _multipliers.Clear();
        for (var i = firstMultiplier; i <= lastMultiplier; i++)
        {
            _multipliers.Add(i);
        }

        return this;
    }

    public DigitChecker ReplaceWith(string substitute, params int[] digits)
    {
        foreach (var digit in digits)
        {
            _substitutions[digit] = substitute;
        }

        return this;
    }

    public void Add(string digit) => _numbers = string.Concat(_numbers, digit);

    public string Calculate() => (_numbers.Length <= 0) ? "" : GetDigitSum();

    private string GetDigitSum()
    {
        var sum = 0;
        var m = 0;
        for (int i = _numbers.Length - 1; i >= 0; i--)
        {
            var product = (int)char.GetNumericValue((char)(_numbers[i] * _multipliers[m]));
            sum += product;

            if (++m >= _multipliers.Count)
            {
                m = 0;
            }
        }

        var mod = (sum % Module);
        var result = _moduleComplement ? Module - mod : mod;

        return _substitutions.TryGetValue(result, out var value)
            ? value
            : result.ToString();
    }
}
