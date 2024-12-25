namespace Day1.Domain.ValueObjects;
public record LocationId(uint Number) : IComparable<LocationId>
{
    int IComparable<LocationId>.CompareTo(LocationId? other)
        => (int)(Number - (other?.Number ?? 0));

    public static implicit operator uint(LocationId locationId) => locationId.Number;
}
