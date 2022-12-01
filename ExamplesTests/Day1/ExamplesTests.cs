using Day1;

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
}