﻿using Day3;

namespace AoC2022.Tests.Day3;

public class ExampleTests
{
    [Fact]
    public async Task TestExample1()
    {
        //Arrange
        var example1Result = uint.Parse(await File.ReadAllTextAsync(@"Day3\example.output1.txt"));
        PartySupplies supplies = await PartySupplies.BuildSuppliesAsync(InputHelpers.GetElfGroupsAsyncEnum(@"Day3\example.input.txt"));

        //Act
        uint totalPrioritiesSum = supplies.CalculatePrioritiesTotalSum();

        //Assert
        Assert.Equal(example1Result, totalPrioritiesSum);
    }

    [Fact]
    public async Task TestExample2()
    {
        //Arrange
        var example2Result = uint.Parse(await File.ReadAllTextAsync(@"Day3\example.output2.txt"));
        PartySupplies supplies = await PartySupplies.BuildSuppliesAsync(InputHelpers.GetElfGroupsAsyncEnum(@"Day3\example.input.txt"));

        //Act
        uint elfGroupsTotalPriorities = supplies.CalculateElfGroupsPrioritiesTotalSum();

        //Assert
        Assert.Equal(example2Result, elfGroupsTotalPriorities);
    }
}
