namespace Day1.Model;

public record Energy(uint Value) : IComparable<Energy>
{
    public static implicit operator uint(Energy calories)
        => calories.Value;

    public static implicit operator Energy(uint value)
        => new(value);

    int IComparable<Energy>.CompareTo(Energy? other)
        => (int)(this - (other ?? 0));

    public override string? ToString()
        => $"{Value} cal.";
}
