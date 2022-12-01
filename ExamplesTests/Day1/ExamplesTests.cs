using Day1;
using Day1.Model;

namespace ExamplesTests.Day1;

public class ExamplesTests
{
    [Fact]
    public async Task TestPuzzle1Async()
    {
        //Arrange
        int puzzle1Result = int.Parse(await File.ReadAllTextAsync(@"Day1\example.output1.txt"));

        //Act
        int maxCaloriesPerElf = await solution.MaxCaloriesPerElf;

        //Assert
        Assert.Equal(puzzle1Result, maxCaloriesPerElf);
    }

    [Fact]
    public async Task TestPuzzle2Async()
    {
        //Arrange
        int puzzle2Result = int.Parse(await File.ReadAllTextAsync(@"Day1\example.output2.txt"));

        //Act
        int totalCaloriesFromTop3Elves = await solution.TotalCaloriesFromTop3Elves;

        //Assert
        Assert.Equal(puzzle2Result, totalCaloriesFromTop3Elves);
    }

    private readonly Solution solution = new(File.ReadLinesAsync(@"Day1\example.input.txt"));

    [Fact]
    public async Task TestExamplesAsync()
    {
        //Arrange
        uint puzzle1Result = uint.Parse(await File.ReadAllTextAsync(@"Day1\example.output1.txt"));
        uint puzzle2Result = uint.Parse(await File.ReadAllTextAsync(@"Day1\example.output2.txt"));
        Expedition expedition = await Expedition.BuildExpeditionAsync(InputHelpers.GetElvesAsync(@"Day1\example.input.txt"));

        //Act
        CaloriesValue maxCaloriesPerElf = await expedition.MaxCaloriesPerElfTask;
        CaloriesValue totalCaloriesFromTop3Elves = await expedition.TotalCaloriesFromTop3ElvesTask;

        //Assert
        Assert.Equal(puzzle1Result, (uint)maxCaloriesPerElf);
        Assert.Equal(puzzle2Result, (uint)totalCaloriesFromTop3Elves);
    }
}