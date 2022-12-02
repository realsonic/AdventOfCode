namespace Day2.Model;

public class Strategy
{
    public IReadOnlyList<StrategyRecord> StrategyRecords;

    public IReadOnlyList<StrategyRecord> CorrectStrategyRecords;

    public Task<uint> TotalPointsTask
        => GetTotalPointsAsync();

    public Task<uint> CorrectTotalPointsAsync
        => GetCorrectTotalPointsAsync();

    public static async Task<Strategy> BuildStrategyAsync(IAsyncEnumerable<StrategyRecord> strategyRecords, IAsyncEnumerable<StrategyRecord> correctStrategyRecords)
    {
        var strategyRecordList = await strategyRecords.ToListAsync();
        var correctStrategyRecordList = await correctStrategyRecords.ToListAsync();
        return new Strategy(strategyRecordList, correctStrategyRecordList);
    }

    private async Task<uint> GetTotalPointsAsync()
        => (uint)await GetRecordPointsAsyncEnum()
        .SumAsync(points => points);

    private async Task<uint> GetCorrectTotalPointsAsync()
        => (uint)await GetCorrectRecordPointsAsyncEnum()
        .SumAsync(points => points);

    private async IAsyncEnumerable<uint> GetRecordPointsAsyncEnum()
    {
        await foreach (var strategyRecord in StrategyRecords.ToAsyncEnumerable())
            yield return await strategyRecord.PointsTask;
    }

    private async IAsyncEnumerable<uint> GetCorrectRecordPointsAsyncEnum()
    {
        await foreach (var correctStrategyRecord in CorrectStrategyRecords.ToAsyncEnumerable())
            yield return await correctStrategyRecord.PointsTask;
    }

    private Strategy(IEnumerable<StrategyRecord> strategyRecords, IReadOnlyList<StrategyRecord> correctStrategyRecords)
    {
        StrategyRecords = strategyRecords.ToList();
        CorrectStrategyRecords = correctStrategyRecords;
    }
}
