using Day1;
using Day1.Model;

namespace ExamplesTests.Day1;

public class ExamplesTests
{
    [Fact]
    public async Task TestExample1Async()
    {
        //Arrange
        var example1Result = uint.Parse(await File.ReadAllTextAsync(@"Day1\example.output1.txt"));
        Expedition expedition = await Expedition.BuildExpeditionAsync(InputHelpers.GetElvesAsync(@"Day1\example.input.txt"));

        //Act
        Energy maxCaloriesPerElf = await expedition.MaxCaloriesPerElfTask;

        //Assert
        Assert.Equal(example1Result, (uint)maxCaloriesPerElf);
    }

    [Fact]
    public async Task TestExample2Async()
    {
        //Arrange
        uint example2Result = uint.Parse(await File.ReadAllTextAsync(@"Day1\example.output2.txt"));
        Expedition expedition = await Expedition.BuildExpeditionAsync(InputHelpers.GetElvesAsync(@"Day1\example.input.txt"));

        //Act
        Energy totalCaloriesFromTop3Elves = await expedition.TotalCaloriesFromTop3ElvesTask;

        //Assert
        Assert.Equal(example2Result, (uint)totalCaloriesFromTop3Elves);
    }
}