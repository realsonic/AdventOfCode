using Day2;
using Day2.Model;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.WriteLine("🌟 Advent of Code 2022. 📅 Day 2.");

Tournament tournament;
var strategy = await Strategy.BuildStrategyAsync(InputHelpers.GetStrategyRecordsAsync(@"input.txt"));
tournament = new Tournament(strategy);
uint totalPoints = await tournament.TotalPointsTask;

var correctStrategy = await Strategy.BuildStrategyAsync(InputHelpers.GetCorrectStrategyRecordsAsync(@"input.txt"));
tournament = new Tournament(correctStrategy);
uint correctTotalPoints = await tournament.TotalPointsTask;

Console.WriteLine(@$"
❓ [Puzzle 1] What would your total score be if everything goes exactly according to your strategy guide?
    ❇️ {totalPoints}
❓ [Puzzle 2] Following the Elf's instructions for the second column, what would your total score be if everything goes exactly according to your strategy guide?
    ❇️ {correctTotalPoints}
");
