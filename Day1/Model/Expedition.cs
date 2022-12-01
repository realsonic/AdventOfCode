namespace Day1.Model;
public class Expedition
{
    public IReadOnlyList<Elf> Elves { get; }

    public Task<CaloriesValue> MaxCaloriesPerElf
        => GetMaxCaloriesPerElfAsync();

    public static async Task<Expedition> BuildExpeditionAsync(IAsyncEnumerable<Elf> elves)
    {
        var elvesList = await elves.ToListAsync();
        return new Expedition(elvesList);
    }

    private Expedition(IEnumerable<Elf> elves)
    {
        Elves = elves.ToList();
    }

    private async Task<CaloriesValue> GetMaxCaloriesPerElfAsync()
        => await GetElvesTotalCarriedCalloriesAsyncEnum().MaxAsync();

    private async IAsyncEnumerable<CaloriesValue> GetElvesTotalCarriedCalloriesAsyncEnum()
    {
        await foreach (var elf in Elves.ToAsyncEnumerable())
        {
            yield return await elf.TotalCarriedCallories;
        }
    }
}
