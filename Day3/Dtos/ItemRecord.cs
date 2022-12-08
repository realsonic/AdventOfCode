namespace Day3.Dtos;

public record ItemRecord(ItemRecord.Type ItemType)
{
    public record Type(char Character)
    {
        public char Character { get; init; }
            = (Character is >= 'a' and <= 'z' or >= 'A' and <= 'Z')
            ? Character
            : throw new ArgumentException($"Type value must be in range a-z or A-Z, but it's = {Character}", nameof(Character));

        public static implicit operator char(Type type) => type.Character;
        public static implicit operator Type(char character) => new(character);
    };
}