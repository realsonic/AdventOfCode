namespace Day3;

public record Elf(Rucksack Rucksack)
{
    public IEnumerable<Item> AllItems
        => Rucksack.FirstCompartment.Items
        .Union(Rucksack.SecondCompartment.Items);
};