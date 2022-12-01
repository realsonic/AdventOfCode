using Day1;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.WriteLine("🌟 Advent of Code 2022. 📅 Day 1.");

var solution = new Solution(File.ReadLinesAsync("input.txt"));
solution.OnSnackCounted += snacksCount => Console.WriteLine($"🔸 Counted {++snacksCount} snacks.");
solution.OnElfCounted += elvesCount => Console.WriteLine($"🔶🔶 Counted {++elvesCount} elves.");

int maxCaloriesPerElfFromSolution = await solution.MaxCaloriesPerElf;
int totalCaloriesFromTop3ElvesFromSolution = await solution.TotalCaloriesFromTop3Elves;

Console.WriteLine(@$"
❓ [Puzzle 1] How many total Calories is that Elf carrying?
    ❇️ {maxCaloriesPerElfFromSolution}
❓ [Puzzle 2] How many Calories are those Elves carrying in total?
    ❇️ {totalCaloriesFromTop3ElvesFromSolution}
");
