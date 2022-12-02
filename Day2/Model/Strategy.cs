namespace Day2.Model;

public class Strategy
{
    public IReadOnlyList<StrategyRecord> StrategyRecords;

    public Task<uint> TotalPointsTask
        => GetTotalPointsAsync();

    public static async Task<Strategy> BuildStrategyAsync(IAsyncEnumerable<StrategyRecord> strategyRecords)
    {
        var strategyRecordList = await strategyRecords.ToListAsync();
        return new Strategy(strategyRecordList);
    }

    private async Task<uint> GetTotalPointsAsync()
        => (uint)await GetRecordPointsAsyncEnum()
        .SumAsync(points => points);

    private async IAsyncEnumerable<uint> GetRecordPointsAsyncEnum()
    {
        await foreach (var strategyRecord in StrategyRecords.ToAsyncEnumerable())
            yield return await strategyRecord.PointsTask;
    }

    private Strategy(IEnumerable<StrategyRecord> strategyRecords)
    {
        StrategyRecords = strategyRecords.ToList();
    }
}
