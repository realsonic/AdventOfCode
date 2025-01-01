using Day2;
using Day2.Model;

namespace AoC2022.Tests.Day2;

public class ExamplesTests
{
    [Fact]
    public async Task TestExample1()
    {
        //Arrange
        var example1Result = uint.Parse(await File.ReadAllTextAsync(@"Day2\example.output1.txt"));
        Strategy strategy = await Strategy.BuildStrategyAsync(InputHelpers.GetStrategyRecordsAsync(@"Day2\example.input.txt"));
        Tournament tournament = new(strategy);

        //Act
        var totalPoints = await tournament.TotalPointsTask;

        //Assert
        Assert.Equal(example1Result, totalPoints);
    }

    [Fact]
    public async Task TextExample2()
    {
        //Arrange
        var example2Result = uint.Parse(await File.ReadAllTextAsync(@"Day2\example.output2.txt"));
        Strategy strategy = await Strategy.BuildStrategyAsync(InputHelpers.GetCorrectStrategyRecordsAsync(@"Day2\example.input.txt"));
        Tournament tournament = new(strategy);

        //Act
        var totalPoints = await tournament.TotalPointsTask;

        //Assert
        Assert.Equal(example2Result, totalPoints);
    }
}
