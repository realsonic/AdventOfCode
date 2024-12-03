namespace Day3.Dtos;

public record InputRecord(ContentRecord FirstCompartmentContents, ContentRecord SecondCompartmentContents)
{
    internal static InputRecord BuildFromString(string record)
    {
        int middleIndex = record.Length / 2;

        string firstHalfOfString = record[..middleIndex];
        ContentRecord firstCompartmentContents = ContentRecord.BuildFromString(firstHalfOfString);

        string secondHalfOfString = record[middleIndex..];
        ContentRecord secondCompartmentContents = ContentRecord.BuildFromString(secondHalfOfString);

        return new InputRecord(firstCompartmentContents, secondCompartmentContents);
    }
}
