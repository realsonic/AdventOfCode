namespace Day2.Model;

public record StrategyRecord(MoveEnum OpponentsMove, MoveEnum MyMove)
{
    public Task<uint> PointsTask
        => GetPointsAsync();

    private async Task<uint> GetPointsAsync()
        => await Task.FromResult(Points);

    public uint Points
        => (uint)MyMove + RoundOutcome;

    public uint RoundOutcome
        => MyMove.PlayAgainst(OpponentsMove) switch
        {
            OutcomeEnum.Win => 6,
            OutcomeEnum.Draw => 3,
            OutcomeEnum.Lost => 0,
            _ => throw new InvalidOperationException($"Wrong outcome {MyMove.PlayAgainst(OpponentsMove)}")
        };
}
