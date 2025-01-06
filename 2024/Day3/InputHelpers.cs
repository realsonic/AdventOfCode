using Day3.Application;
using Day3.Domain;

namespace Day3;
public class InputHelpers
{
    public static Memory LoadMemoryFromFile(string inputFilePath) => new(LoadMulsFromFile(inputFilePath).ToBlockingEnumerable().ToList());

    public static async IAsyncEnumerable<Command> LoadMulsFromFile(string inputFilePath)
    {
        string input = await File.ReadAllTextAsync(inputFilePath);

        CommandReader mulReader = new(input);
        foreach (Command mul in mulReader.ReadCommands())
        {
            yield return mul;
        }
    }
}
