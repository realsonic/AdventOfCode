using Day3;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.WriteLine("🌟 Advent of Code 2022. 📅 Day 2.");

Supplies supplies = await Supplies.BuildSuppliesAsync(InputHelpers.GetRucksacksAsyncEnum("input.txt"));
uint totalPrioritiesSum = await supplies.CalculateTotalPrioritiesSumAsync();

Console.WriteLine($"""
    ❓ [Puzzle 1] What is the sum of the priorities of those item types? 
       ❇️ {totalPrioritiesSum}
    """);