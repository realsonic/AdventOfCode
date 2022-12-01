using Day1.Dtos;
using Day1.Model;

namespace ExamplesTests.Day1;

public static class InputHelpers
{
    public static async IAsyncEnumerable<Elf> GetElvesAsync(string inputFilePath)
    {
        List<Snack> snacks = new();

        await foreach (var inputRecord in GetInputRecordsAsync(inputFilePath))
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

    private static async IAsyncEnumerable<InputRecord> GetInputRecordsAsync(string inputFilePath)
    {
        await foreach (string record in File.ReadLinesAsync(inputFilePath))
            yield return InputRecord.BuildFromString(record);
    }
}