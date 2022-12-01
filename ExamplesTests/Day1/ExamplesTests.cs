using Day1;
using Day1.Dtos;
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
    public async Task Test_Expedition()
    {
        //Arrange
        uint puzzle1Result = uint.Parse(await File.ReadAllTextAsync(@"Day1\example.output1.txt"));
        Expedition expedition = await Expedition.BuildExpeditionAsync(GetElvesAsync());

        //Act
        CaloriesValue maxCaloriesPerElf = await expedition.MaxCaloriesPerElf;

        //Assert
        Assert.Equal(puzzle1Result, maxCaloriesPerElf);
    }

    private static async IAsyncEnumerable<Elf> GetElvesAsync()
    {
        List<Snack> snacks = new();

        await foreach (var inputRecord in GetInputRecordsAsync())
        {
            if (inputRecord is CaloriesRecord caloriesRecord)
            {
                snacks.Add(new Snack(caloriesRecord.Calories));
            }
            else if (inputRecord is DelimiterRecord)
            {
                yield return new Elf(snacks);
                snacks.Clear();
            }
        }

        if (snacks.Count > 0)
        {
            yield return new Elf(snacks);
        }
    }

    private static async IAsyncEnumerable<InputRecord> GetInputRecordsAsync()
    {
        await foreach (string record in File.ReadLinesAsync(@"Day1\example.input.txt"))
            yield return InputRecord.BuildFromString(record);

        yield return new DelimiterRecord();
    }
}