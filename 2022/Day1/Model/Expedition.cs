namespace Day1.Model;

public class Expedition
{
    public IReadOnlyList<Elf> Elves { get; }

    public Task<Energy> MaxCaloriesPerElfTask
        => GetMaxCaloriesPerElfAsync();

    public Task<Energy> TotalCaloriesFromTop3ElvesTask
        => GetTotalCaloriesFromTop3ElvesAsync();

    public static async Task<Expedition> BuildExpeditionAsync(IAsyncEnumerable<Elf> elves)
    {
        var elvesList = await elves.ToListAsync();
        return new Expedition(elvesList);
    }

    private Expedition(IEnumerable<Elf> elves)
    {
        Elves = elves.ToList();
    }

    private async Task<Energy> GetMaxCaloriesPerElfAsync()
        => await GetElvesTotalCarriedCalloriesAsyncEnum()
        .MaxAsync();

    private async Task<Energy> GetTotalCaloriesFromTop3ElvesAsync()
        => (Energy)await GetElvesTotalCarriedCalloriesAsyncEnum()
        .OrderByDescending(caloriesValue => caloriesValue)
        .Take(3)
        .Select(caloriesValue => (long)caloriesValue)
        .SumAsync();

    private async IAsyncEnumerable<Energy> GetElvesTotalCarriedCalloriesAsyncEnum()
    {
        await foreach (var elf in Elves.ToAsyncEnumerable())
        {
            yield return await elf.TotalCarriedCalloriesTask;
        }
    }
}
