﻿using Day2;
using Day2.Model;

namespace ExamplesTests.Day2;

public class ExamplesTests
{
    [Fact]
    public async Task TestExample1Async()
    {
        //Arrange
        var example1Result = uint.Parse(await File.ReadAllTextAsync(@"Day2\example.output1.txt"));

        //Act
        Strategy strategy = await Strategy.BuildStrategyAsync(InputHelpers.GetStrategyRecordsAsync(@"Day2\example.input.txt"));
        var totalPoints = await strategy.TotalPointsTask;

        //Assert
        Assert.Equal(example1Result, totalPoints);
    }
}