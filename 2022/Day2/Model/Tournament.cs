namespace Day2.Model;

public class Tournament
{
    public Strategy Strategy { get; }

    public Task<uint> TotalPointsTask
        => GetTotalPointsAsync();

    public Tournament(Strategy strategy)
    {
        Strategy = strategy;
    }

    private async Task<uint> GetTotalPointsAsync()
        => (uint)await GetRecordPointsAsyncEnum()
        .SumAsync(points => points);

    private async IAsyncEnumerable<uint> GetRecordPointsAsyncEnum()
    {
        await foreach (var strategyRecord in Strategy.StrategyRecords.ToAsyncEnumerable())
            yield return await CalculatePoints(strategyRecord);
    }

    private static async Task<uint> CalculatePoints(StrategyRecord strategyRecord)
        => await CalculateMyMovePointsAsync(strategyRecord.MyMove) + await CalulateRoundOutcomeAsync(strategyRecord);

    private static async Task<uint> CalculateMyMovePointsAsync(MoveEnum myMove)
        => await Task.FromResult<uint>(
            myMove switch
            {
                MoveEnum.Rock => 1,
                MoveEnum.Paper => 2,
                MoveEnum.Scissors => 3,
                _ => throw new InvalidOperationException($"Wrong my move {myMove}")
            });

    private static async Task<uint> CalulateRoundOutcomeAsync(StrategyRecord strategyRecord)
    {
        OutcomeEnum outcome = strategyRecord.MyMove.PlayAgainst(strategyRecord.OpponentsMove);
        return await Task.FromResult<uint>(
            outcome switch
            {
                OutcomeEnum.Win => 6,
                OutcomeEnum.Draw => 3,
                OutcomeEnum.Lost => 0,
                _ => throw new InvalidOperationException($"Wrong outcome {outcome}")
            });
    }
}
