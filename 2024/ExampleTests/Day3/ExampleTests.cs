using Day3;
using Day3.Domain;

using FluentAssertions;

namespace AoC2024.Tests.Day3;
public class ExampleTests
{
    [Fact(DisplayName = "First example succeeds")]
    public async Task TestExample1()
    {
        // Arrange
        int example1Result = int.Parse(await File.ReadAllTextAsync(@"Day3\example.output1.txt"));
        Memory memory = InputHelpers.LoadMemoryFromFile(@"Day3\example.input1.txt");

        // Act
        int summary = memory.Summary;

        // Assert
        summary.Should().Be(example1Result);
    }
    
    [Fact(DisplayName = "Second example succeeds")]
    public async Task TestExample2()
    {
        // Arrange
        int example2Result = int.Parse(await File.ReadAllTextAsync(@"Day3\example.output2.txt"));
        Memory memory = InputHelpers.LoadMemoryFromFile(@"Day3\example.input2.txt");

        // Act
        int summary = memory.EnabledSummary;

        // Assert
        summary.Should().Be(example2Result);
    }
}
