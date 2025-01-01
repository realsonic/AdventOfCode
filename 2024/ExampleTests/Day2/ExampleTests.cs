using Day2;
using Day2.Domain;

using FluentAssertions;

namespace AoC2024.ExampleTests.Day2;

public class ExampleTests
{
    [Fact]
    public async Task TestExample1()
    {
        // Arrange
        int example1Result = int.Parse(await File.ReadAllTextAsync(@"Day2\example.output1.txt"));
        IAsyncEnumerable<Report> reportsAsync = InputHelpers.LoadReportsFromFile(@"Day2\example.input.txt");

        // Act
        int safeReports = 0;
        await foreach (Report report in reportsAsync)
        {
            if (report.IsSafe)
            {
                safeReports++;
            }
        }

        // Assure
        safeReports.Should().Be(example1Result);
    }
}
