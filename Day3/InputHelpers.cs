using Day3.Dtos;

namespace Day3;

public class InputHelpers
{
    public static async IAsyncEnumerable<Rucksack> GetRucksacksAsyncEnum(string inputFilePath)
    {
        await foreach (InputRecord inputRecord in GetInputRecordsAsyncEnum(inputFilePath))
            yield return await BuildRucksackFromInputRecordAsync(inputRecord);
    }

    private static async Task<Rucksack> BuildRucksackFromInputRecordAsync(InputRecord inputRecord)
        => await Task.FromResult(
                new Rucksack(
                    FirstCompartment: await BuildCompartmentFromComaptmentRecordAsync(inputRecord.FirstCompartmentContents),
                    SecondCompartment: await BuildCompartmentFromComaptmentRecordAsync(inputRecord.SecondCompartmentContents)
                )
            );

    private static async Task<Compartment> BuildCompartmentFromComaptmentRecordAsync(ContentRecord compartmentContents)
    {
        List<Item> items = new();

        await foreach (ItemRecord itemRecord in compartmentContents.Items.ToAsyncEnumerable())
            items.Add(await BuildItemFromItemRecordAsync(itemRecord));

        return new Compartment(items.ToArray());
    }

    private static async Task<Item> BuildItemFromItemRecordAsync(ItemRecord itemRecord)
        => await Task.FromResult(new Item(itemRecord.ItemType.Character));

    private static async IAsyncEnumerable<InputRecord> GetInputRecordsAsyncEnum(string inputFilePath)
    {
        await foreach (string record in File.ReadLinesAsync(inputFilePath))
            yield return InputRecord.BuildFromString(record);
    }
}