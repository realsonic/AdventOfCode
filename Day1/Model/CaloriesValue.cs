namespace Day1.Model;

public record CaloriesValue(uint Value) : IComparable<CaloriesValue>
{
    public static implicit operator uint(CaloriesValue calories)
        => calories.Value;

    public static implicit operator CaloriesValue(uint value)
        => new(value);

    int IComparable<CaloriesValue>.CompareTo(CaloriesValue? other)
        => (int)(this - (other ?? 0));
}
