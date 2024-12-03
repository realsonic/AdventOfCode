using Day3;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.WriteLine("🌟 Advent of Code 2022. 📅 Day 3.");

PartySupplies partySupplies = await PartySupplies.BuildSuppliesAsync(InputHelpers.GetElfGroupsAsyncEnum("input.txt"));
uint totalPrioritiesSum = partySupplies.CalculatePrioritiesTotalSum();
uint elfGroupsPrioritiesTotalSum = partySupplies.CalculateElfGroupsPrioritiesTotalSum();

Console.WriteLine($"""
    ❓ [Puzzle 1] What is the sum of the priorities of those item types? 
        ❇️ {totalPrioritiesSum}
    ❓ [Puzzle 2] What is the sum of the priorities of those item types?
        ❇️ {elfGroupsPrioritiesTotalSum}
    """);