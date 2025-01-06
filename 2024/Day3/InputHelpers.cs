using Day3.Application;
using Day3.Domain;

namespace Day3;
public class InputHelpers
{
    public static Memory LoadMemoryFromFile(string inputFilePath) => new(LoadCommandsFromFile(inputFilePath).ToBlockingEnumerable().ToList());

    public static async IAsyncEnumerable<Command> LoadCommandsFromFile(string inputFilePath)
    {
        string input = await File.ReadAllTextAsync(inputFilePath);

        CommandReader commandReader = new(input);
        foreach (Command command in commandReader.ReadCommands())
        {
            yield return command;
        }
    }
}
