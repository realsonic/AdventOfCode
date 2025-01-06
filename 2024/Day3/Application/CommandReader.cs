using Day3.Domain;

using System.Text.RegularExpressions;

namespace Day3.Application;
public class CommandReader(string input)
{
    public IEnumerable<Command> ReadCommands()
    {
        foreach (Match commandMatch in CommandRegexes.MulDoDontRegex().Matches(input))
        {
            switch (commandMatch.Groups["command"].Value)
            {
                case "mul":
                    Group firstNumberGroup = commandMatch.Groups["first"];
                    if (!int.TryParse(firstNumberGroup.Value, out int firstNumber))
                        throw new InvalidOperationException($"First number ({firstNumberGroup.Value}) isn't integer in found mul ({commandMatch.Value})");

                    Group secondNumberGroup = commandMatch.Groups["second"];
                    if (!int.TryParse(secondNumberGroup.Value, out int secondNumber))
                        throw new InvalidOperationException($"First number ({secondNumberGroup.Value}) isn't integer in found mul ({commandMatch.Value})");

                    yield return new Mul(firstNumber, secondNumber);
                    break;

                case "do":
                    yield return new Do();
                    break;

                case "don't":
                    yield return new Dont();
                    break;
            }
        }
    }
}
