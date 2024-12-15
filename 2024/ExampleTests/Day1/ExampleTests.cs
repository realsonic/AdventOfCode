using Day1;
using Day1.Domain;

using FluentAssertions;

namespace ExampleTests.Day1;

public class ExampleTests
{
    [Fact]
    public async Task TestExample1Async()
    {
        // Arrange
        long example1Result = long.Parse(await File.ReadAllTextAsync(@"Day1\example.output1.txt"));
        ListComparision listComparision = await InputHelpers.LoadListComparisonFromFile(@"Day1\example.input.txt");

        // Act
        long totalDistance = listComparision.TotalDistance;

        // Assert
        totalDistance.Should().Be(example1Result);
    }
}