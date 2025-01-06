using Day3.Application;

using FluentAssertions;

using System.Text.RegularExpressions;

namespace AoC2024.Tests.Day3;

/// <summary>
/// Command regexes tests.
/// </summary>
public partial class RegexTests
{
    [Fact(DisplayName = "Mul command parsed")]
    public void TestMulRegex()
    {
        // Arrange
        string input = @"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

        // Act
        List<(string First, string Second)> matchedNumbers = [];
        foreach (Match match in CommandRegexes.MulRegex().Matches(input))
        {
            matchedNumbers.Add((First: match.Groups["first"].Value, Second: match.Groups["second"].Value));
        }

        // Assert
        matchedNumbers.Should().BeEquivalentTo([("2", "4"), ("5", "5"), ("11", "8"), ("8", "5")]);
    }

    [Fact(DisplayName = "Mul and Do/Don't commands parsed")]
    public void TestMulDoDontRegex()
    {
        // Arrange
        string input = @"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

        // Act
        List<(string Command, string First, string Second)> matchedNumbers = [];
        foreach (Match match in CommandRegexes.MulDoDontRegex().Matches(input))
        {
            matchedNumbers.Add((
                Command: match.Groups["command"].Value, 
                First: match.Groups["first"].Value, 
                Second: match.Groups["second"].Value
            ));
        }

        // Assert
        matchedNumbers.Should().BeEquivalentTo(
        [
            ("mul", "2", "4"),
            ("don't", "", ""),
            ("mul", "5", "5"),
            ("mul", "11", "8"),
            ("do", "", ""),
            ("mul", "8", "5")
        ]);
    }
}
