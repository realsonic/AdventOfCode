using Day2;
using Day2.Model;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.WriteLine("🌟 Advent of Code 2022. 📅 Day 2.");

var strategy = await Strategy.BuildStrategyAsync(InputHelpers.GetStrategyRecordsAsync(@"input.txt"));
var correctStrategy = await Strategy.BuildStrategyAsync(InputHelpers.GetCorrectStrategyRecordsAsync(@"input.txt"));

uint totalPoints = await strategy.TotalPointsTask;
uint correctTotalPoints = await correctStrategy.TotalPointsTask;

Console.WriteLine(@$"
❓ [Puzzle 1] What would your total score be if everything goes exactly according to your strategy guide?
    ❇️ {totalPoints}
❓ [Puzzle 2] Following the Elf's instructions for the second column, what would your total score be if everything goes exactly according to your strategy guide?
    ❇️ {correctTotalPoints}
");
