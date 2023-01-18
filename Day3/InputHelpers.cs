using Day3.Dtos;

namespace Day3;

public class InputHelpers
{
    public static async IAsyncEnumerable<ElfGroup> GetElfGroupsAsyncEnum(string inputFilePath)
    {
        List<Elf> elves = new();

        await foreach (Elf elf in GetElvesAsyncEnum(inputFilePath))
        {
            elves.Add(elf);
            if (elves.Count == 3)
            {
                yield return new ElfGroup(elves[0], elves[1], elves[2]);
                elves.Clear();
            }
        }
    }

    private static async IAsyncEnumerable<Elf> GetElvesAsyncEnum(string inputFilePath)
    {
        await foreach (Rucksack rucksack in GetRucksacksAsyncEnum(inputFilePath))
            yield return new Elf(rucksack);
    }

    private static async IAsyncEnumerable<Rucksack> GetRucksacksAsyncEnum(string inputFilePath)
    {
        await foreach (InputRecord inputRecord in GetInputRecordsAsyncEnum(inputFilePath))
            yield return BuildRucksackFromInputRecord(inputRecord);
    }

    private static Rucksack BuildRucksackFromInputRecord(InputRecord inputRecord)
        => new(
            FirstCompartment: BuildCompartmentFromComaptmentRecord(inputRecord.FirstCompartmentContents),
            SecondCompartment: BuildCompartmentFromComaptmentRecord(inputRecord.SecondCompartmentContents)
        );

    private static Compartment BuildCompartmentFromComaptmentRecord(ContentRecord compartmentContents)
    {
        List<Item> items = new();

        foreach (ItemRecord itemRecord in compartmentContents.Items)
            items.Add(BuildItemFromItemRecord(itemRecord));

        return new Compartment(items.ToArray());
    }

    private static Item BuildItemFromItemRecord(ItemRecord itemRecord)
        => new(itemRecord.ItemType.Character);

    private static async IAsyncEnumerable<InputRecord> GetInputRecordsAsyncEnum(string inputFilePath)
    {
        await foreach (string record in File.ReadLinesAsync(inputFilePath))
            yield return InputRecord.BuildFromString(record);
    }
}