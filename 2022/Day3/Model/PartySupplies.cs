namespace Day3;

public class PartySupplies
{
    public IReadOnlyList<ElfGroup> ElfGroups { get; }

    public IReadOnlyList<Rucksack> AllRucksacks
        => ElfGroups.SelectMany(elfGroup => elfGroup.AllRucksacks).ToList();

    public static async Task<PartySupplies> BuildSuppliesAsync(IAsyncEnumerable<ElfGroup> elfGroups)
        => new PartySupplies(await elfGroups.ToListAsync());

    public uint CalculatePrioritiesTotalSum()
    {
        uint total = 0;
        foreach (var rucksack in AllRucksacks)
        {
            Item doubledItem = rucksack.DoubleItem;
            total += GetItemTypePriority(doubledItem.ItemType);
        }
        return total;
    }

    public uint CalculateElfGroupsPrioritiesTotalSum()
    {
        uint total = 0;
        foreach (var elfGroup in ElfGroups)
        {
            Item sameItem = elfGroup.GetSameItem();
            total += GetItemTypePriority(sameItem.ItemType);
        }
        return total;
    }

    private static byte GetItemTypePriority(Item.Type itemType)
        => (byte)(itemType.Character switch
        {
            >= 'a' and <= 'z' => itemType - 'a' + 1,
            >= 'A' and <= 'Z' => itemType - 'A' + 27,
            _ => throw new ArgumentException($"Wrong item type {itemType}", nameof(itemType))
        });

    private PartySupplies(List<ElfGroup> elfGroups)
    {
        ElfGroups = elfGroups;
    }
}