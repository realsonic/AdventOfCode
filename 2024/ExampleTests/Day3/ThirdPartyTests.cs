using FluentAssertions;

using System.Text.RegularExpressions;

namespace AoC2024.Tests.Day3;

/// <summary>
/// Third party libraries (inlcuding .NET) tests.
/// </summary>
/// <remarks>This one is needed for checking of right understanding of libraries specification.</remarks>
public partial class ThirdPartyTests
{
    [Fact]
    public void TestRegex()
    {
        // Arrange
        string input = @"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

        // Act
        List<(string First, string Second)> matchedNumbers = [];
        foreach (Match match in TestMulRegex().Matches(input))
        {
            matchedNumbers.Add((First: match.Groups["first"].Value, Second: match.Groups["second"].Value));
        }

        // Assert
        matchedNumbers.Should().BeEquivalentTo([("2", "4"), ("5", "5"), ("11", "8"), ("8", "5")]);
    }

    [GeneratedRegex(@"mul\((?'first'\d{1,3}),(?'second'\d{1,3})\)")]
    private static partial Regex TestMulRegex();
}
