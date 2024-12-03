namespace Day1.Dtos;

public record InputRecord()
{
    public static InputRecord BuildFromString(string record)
        => !string.IsNullOrEmpty(record)
            ? new CaloriesRecord(uint.Parse(record))
            : new DelimiterRecord();
};

public record CaloriesRecord(uint Calories) : InputRecord;

public record DelimiterRecord() : InputRecord;
