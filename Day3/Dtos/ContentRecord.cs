namespace Day3.Dtos;

public record ContentRecord(ItemRecord[] Items)
{
    internal static ContentRecord BuildFromString(string content)
    {
        ItemRecord[] items = content
                    .Select(character => new ItemRecord(new ItemRecord.Type(character)))
                    .ToArray();
        return new ContentRecord(items);
    }
}
