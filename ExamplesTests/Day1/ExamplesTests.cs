using Day1.Model;

namespace ExamplesTests.Day1;

public class ExamplesTests
{
    [Fact]
    public async Task TestExample1Async()
    {
        //Arrange
        var example1Result = uint.Parse(await File.ReadAllTextAsync(@"Day1\example.output1.txt"));

        //Act
        Expedition expedition = await Expedition.BuildExpeditionAsync(InputHelpers.GetElvesAsync(@"Day1\example.input.txt"));
        CaloriesValue maxCaloriesPerElf = await expedition.MaxCaloriesPerElfTask;

        //Assert
        Assert.Equal(example1Result, (uint)maxCaloriesPerElf);
    }

    [Fact]
    public async Task TestExample2Async()
    {
        //Arrange
        uint example2Result = uint.Parse(await File.ReadAllTextAsync(@"Day1\example.output2.txt"));

        //Act
        Expedition expedition = await Expedition.BuildExpeditionAsync(InputHelpers.GetElvesAsync(@"Day1\example.input.txt"));
        CaloriesValue totalCaloriesFromTop3Elves = await expedition.TotalCaloriesFromTop3ElvesTask;

        //Assert
        Assert.Equal(example2Result, (uint)totalCaloriesFromTop3Elves);
    }
}