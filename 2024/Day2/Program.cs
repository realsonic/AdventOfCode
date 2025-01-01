using Day2;
using Day2.Domain;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.WriteLine("🌟 Advent of Code 2024. 📅 Day 2.");

IAsyncEnumerable<Report> reportsAsync = InputHelpers.LoadReportsFromFile("input.txt");
int safeReports = 0;
await foreach (Report report in reportsAsync)
{
    if (report.IsSafe)
    {
        safeReports++;
    }
}

Console.WriteLine(@$"
❓ [Puzzle 1] How many reports are safe?
    ❇️ {safeReports}
❓ [Puzzle 2] 
    ❇️ 
");
