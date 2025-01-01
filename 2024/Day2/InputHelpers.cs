using Day2.Domain;
using Day2.Domain.ValueObjects;

namespace Day2;

public class InputHelpers
{
    public static async IAsyncEnumerable<Report> LoadReportsFromFile(string inputFilePath)
    {
        await foreach (string record in File.ReadLinesAsync(inputFilePath))
        {
            yield return new Report(LoadLevelsFromString(record));
        }
    }

    public static IEnumerable<Level> LoadLevelsFromString(string record)
    {
        string[] strNumbers = record.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        foreach (string strNumber in strNumbers)
        {
            if (int.TryParse(strNumber, out int number))
            {
                yield return new Level(number);
            }
            else
            {
                throw new InvalidOperationException($"Уровень ({strNumber}) должен быть целым числом");
            }
        }
    }
}
