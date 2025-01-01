using Day3;
using Day3.Domain;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.WriteLine("🌟 Advent of Code 2024. 📅 Day 3.");

Memory memory = InputHelpers.LoadMemoryFromFile(@"input.txt");

Console.WriteLine(@$"
❓ [Puzzle 1] What do you get if you add up all of the results of the multiplications?
    👉 {memory.Summary}
");
