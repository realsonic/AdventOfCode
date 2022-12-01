namespace Day1.Model;

public class Expedition
{
    public IReadOnlyList<Elf> Elves { get; }

    public Task<CaloriesValue> MaxCaloriesPerElfTask
        => GetMaxCaloriesPerElfAsync();

    public Task<CaloriesValue> TotalCaloriesFromTop3ElvesTask
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

    private async Task<CaloriesValue> GetMaxCaloriesPerElfAsync()
        => await GetElvesTotalCarriedCalloriesAsyncEnum()
        .MaxAsync();

    private async Task<CaloriesValue> GetTotalCaloriesFromTop3ElvesAsync()
        => (CaloriesValue)await GetElvesTotalCarriedCalloriesAsyncEnum()
        .OrderByDescending(caloriesValue => caloriesValue)
        .Take(3)
        .Select(caloriesValue => (long)caloriesValue)
        .SumAsync();

    private async IAsyncEnumerable<CaloriesValue> GetElvesTotalCarriedCalloriesAsyncEnum()
    {
        await foreach (var elf in GetElvesAsyncEnum())
        {
            yield return await elf.TotalCarriedCalloriesTask;
        }
    }

    private async IAsyncEnumerable<Elf> GetElvesAsyncEnum()
    {
        await foreach (var elf in Elves.ToAsyncEnumerable())
        {
            yield return await Task.FromResult(elf);
        }
    }
}
