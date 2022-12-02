using Day1;
using Day1.Model;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.WriteLine("🌟 Advent of Code 2022. 📅 Day 1.");

var expedition = await Expedition.BuildExpeditionAsync(InputHelpers.GetElvesAsync(@"input.txt"));

CaloriesValue maxCaloriesPerElf = await expedition.MaxCaloriesPerElfTask;
CaloriesValue totalCaloriesFromTop3Elves = await expedition.TotalCaloriesFromTop3ElvesTask;

Console.WriteLine(@$"
❓ [Puzzle 1] How many total Calories is that Elf carrying?
    ❇️ {maxCaloriesPerElf}
❓ [Puzzle 2] How many Calories are those Elves carrying in total?
    ❇️ {totalCaloriesFromTop3Elves}
");
