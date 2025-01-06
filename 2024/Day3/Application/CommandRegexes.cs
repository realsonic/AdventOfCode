using System.Text.RegularExpressions;

namespace Day3.Application;

public partial class CommandRegexes
{
    [GeneratedRegex(@"mul\((?'first'\d{1,3}),(?'second'\d{1,3})\)")]
    public static partial Regex MulRegex();

    [GeneratedRegex(@"(?'command'mul)\((?'first'\d{1,3}),(?'second'\d{1,3})\)|(?'command'do)\(\)|(?'command'don't)\(\)")]
    public static partial Regex MulDoDontRegex();
}