using Day3.Application;
using Day3.Domain;

namespace Day3;
public class InputHelpers
{
    public static Memory LoadMemoryFromFile(string inputFilePath) => new(LoadMulsFromFile(inputFilePath).ToBlockingEnumerable());

    public static async IAsyncEnumerable<Mul> LoadMulsFromFile(string inputFilePath)
    {
        string input = await File.ReadAllTextAsync(inputFilePath);

        MulReader mulReader = new(input);
        foreach (Mul mul in mulReader.ReadMuls())
        {
            yield return mul;
        }
    }
}
