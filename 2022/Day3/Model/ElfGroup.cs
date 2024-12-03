namespace Day3;

public record ElfGroup(Elf FirstElf, Elf SecondElf, Elf ThirdElf)
{
    public IEnumerable<Rucksack> AllRucksacks
    {
        get
        {
            yield return FirstElf.Rucksack;
            yield return SecondElf.Rucksack;
            yield return ThirdElf.Rucksack;
        }
    }

    public Item GetSameItem()
        => FirstElf.AllItems
            .Intersect(SecondElf.AllItems)
            .Intersect(ThirdElf.AllItems)
            .Single();
}