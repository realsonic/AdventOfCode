namespace Day2.Domain.ValueObjects;
public record Level(int Number)
{
    public static implicit operator int(Level level) => level.Number;
}
