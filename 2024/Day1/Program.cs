using Day1;
using Day1.Domain;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.WriteLine("🌟 Advent of Code 2024. 📅 Day 1.");

ListComparision listComarision = await InputHelpers.LoadListComparisonFromFile("input.txt");

long totalDistance = listComarision.TotalDistance;
long similarityScore = listComarision.SimilarityScore;

Console.WriteLine(@$"
❓ [Puzzle 1] What is the total distance between your lists?
    ❇️ {totalDistance}
❓ [Puzzle 2] What is their similarity score?
    ❇️ {similarityScore}
");
