namespace Day3;

public class Supplies
{
    public IReadOnlyList<Rucksack> Rucksacks { get; }

    public static async Task<Supplies> BuildSuppliesAsync(IAsyncEnumerable<Rucksack> rucksacks)
    {
        List<Rucksack> rucksacksList = await rucksacks.ToListAsync();
        return new Supplies(rucksacksList);
    }

    public async Task<uint> CalculateTotalPrioritiesSumAsync()
    {
        uint total = 0;
        await foreach (var rucksack in Rucksacks.ToAsyncEnumerable())
        {
            Item doubledItem = await rucksack.GetDoubleItemAsync();
            total += await GetItemTypePriorityAsync(doubledItem.ItemType);
        }
        return total;
    }

    private static async Task<byte> GetItemTypePriorityAsync(Item.Type itemType)
        => await Task.FromResult(
            (byte)(itemType.Character switch
            {
                >= 'a' and <= 'z' => itemType - 'a' + 1,
                >= 'A' and <= 'Z' => itemType - 'A' + 27,
                _ => throw new ArgumentException($"Wrong item type {itemType}", nameof(itemType))
            })
        );

    private Supplies(IEnumerable<Rucksack> rucksacks)
    {
        Rucksacks = rucksacks.ToList();
    }
}