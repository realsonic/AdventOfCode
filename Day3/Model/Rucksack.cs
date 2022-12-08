namespace Day3;

public record Rucksack(Compartment FirstCompartment, Compartment SecondCompartment)
{
    public async Task<Item> GetDoubleItemAsync()
        => await Task.Run(() =>
            FirstCompartment.Items.Intersect(SecondCompartment.Items).Single()
        );
}
