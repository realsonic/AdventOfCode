namespace Day3;

public record Rucksack(Compartment FirstCompartment, Compartment SecondCompartment)
{
    public Item DoubleItem => FirstCompartment.Items
        .Intersect(SecondCompartment.Items)
        .Single();
}
