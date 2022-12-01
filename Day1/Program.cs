Console.WriteLine("Advent of Code 2022. Day 1.");
Console.OutputEncoding = System.Text.Encoding.Unicode;

IAsyncEnumerable<string> inputAsyncEnumarable = File.ReadLinesAsync("input.txt");

var elvesCalories = new List<int>() { 0 };

int snacksCount = 0;
await foreach (var snackRecord in inputAsyncEnumarable)
{
	if (!string.IsNullOrEmpty(snackRecord))
	{
		var snackCalories = int.Parse(snackRecord);
		elvesCalories[^1] += snackCalories;
		Console.WriteLine($"🔸 Counted {++snacksCount} snacks.");
	}
	else
	{
		elvesCalories.Add(0);
		Console.WriteLine($"\t🔶 Counted {elvesCalories.Count - 1} elves.");
	}
}
Console.WriteLine($"🔸 Counted {elvesCalories.Count} elves.");

int maxCalories = elvesCalories.Max();
Console.WriteLine($"\n❔ How many total Calories is that Elf carrying? ❇️ {maxCalories}.");

int totalCaloriesFromTop3Elves = elvesCalories.OrderDescending().Take(3).Sum();
Console.WriteLine($"\n❔ How many Calories are those Elves carrying in total? ❇️ {totalCaloriesFromTop3Elves}");