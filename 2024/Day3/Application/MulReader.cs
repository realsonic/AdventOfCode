using Day3.Domain;

using System.Text.RegularExpressions;

namespace Day3.Application;
public partial class MulReader(string input)
{
    public IEnumerable<Mul> ReadMuls()
    {
        foreach (Match mulMatch in MulRegex().Matches(input))
        {
            Group firstNumberGroup = mulMatch.Groups["first"];
            if (!int.TryParse(firstNumberGroup.Value, out int firstNumber))
                throw new InvalidOperationException($"First number ({firstNumberGroup.Value}) isn't integer in found mul ({mulMatch.Value})");

            Group secondNumberGroup = mulMatch.Groups["second"];
            if (!int.TryParse(secondNumberGroup.Value, out int secondNumber))
                throw new InvalidOperationException($"First number ({secondNumberGroup.Value}) isn't integer in found mul ({mulMatch.Value})");

            yield return new Mul(firstNumber, secondNumber);
        }
    }

    [GeneratedRegex(@"mul\((?'first'\d{1,3}),(?'second'\d{1,3})\)")]
    private static partial Regex MulRegex();
}
