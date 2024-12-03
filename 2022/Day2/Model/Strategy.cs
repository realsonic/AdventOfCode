namespace Day2.Model;

public class Strategy
{
    public IReadOnlyList<StrategyRecord> StrategyRecords { get; }

    public static async Task<Strategy> BuildStrategyAsync(IAsyncEnumerable<StrategyRecord> strategyRecords)
    {
        var strategyRecordList = await strategyRecords.ToListAsync();
        return new Strategy(strategyRecordList);
    }

    private Strategy(IEnumerable<StrategyRecord> strategyRecords)
    {
        StrategyRecords = strategyRecords.ToList();
    }
}
