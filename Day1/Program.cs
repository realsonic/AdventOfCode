using Day1.Model;

using ExamplesTests.Day1;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.WriteLine("🌟 Advent of Code 2022. 📅 Day 1.");

var expedition = await Expedition.BuildExpeditionAsync(InputHelpers.GetElvesAsync(@"input.txt"));

CaloriesValue maxCaloriesPerElfFromSolution = await expedition.MaxCaloriesPerElfTask;
CaloriesValue totalCaloriesFromTop3ElvesFromSolution = await expedition.TotalCaloriesFromTop3ElvesTask;

Console.WriteLine(@$"
❓ [Puzzle 1] How many total Calories is that Elf carrying?
    ❇️ {maxCaloriesPerElfFromSolution}
❓ [Puzzle 2] How many Calories are those Elves carrying in total?
    ❇️ {totalCaloriesFromTop3ElvesFromSolution}
");
