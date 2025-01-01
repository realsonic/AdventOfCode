using Day1;
using Day1.Domain;

using FluentAssertions;

namespace AoC2024.ExampleTests.Day1;

public class ExampleTests
{
    [Fact]
    public async Task TestExample1()
    {
        // Arrange
        long example1Result = long.Parse(await File.ReadAllTextAsync(@"Day1\example.output1.txt"));
        ListComparision listComparision = await InputHelpers.LoadListComparisonFromFile(@"Day1\example.input.txt");

        // Act
        long totalDistance = listComparision.TotalDistance;

        // Assert
        totalDistance.Should().Be(example1Result);
    }

    [Fact]
    public async Task TestExample2()
    {
        // Arrange
        long example2Result = long.Parse(await File.ReadAllTextAsync(@"Day1\example.output2.txt"));
        ListComparision listComparision = await InputHelpers.LoadListComparisonFromFile(@"Day1\example.input.txt");

        // Act
        long similarityScore = listComparision.SimilarityScore;

        // Assert
        similarityScore.Should().Be(example2Result);
    }
}