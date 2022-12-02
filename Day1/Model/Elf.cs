namespace Day1.Model;
public class Elf
{
    public IReadOnlyList<Snack> Snacks { get; }

    public Task<Energy> TotalCarriedCalloriesTask
        => Task.Run(() => (Energy)Snacks.Sum(snack => snack.Calories));

    public Elf(IList<Snack> snacks)
    {
        Snacks = snacks.ToList();
    }
}
