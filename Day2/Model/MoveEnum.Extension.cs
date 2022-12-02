namespace Day2.Model;

public static class MoveEnumExtension
{
    public static OutcomeEnum PlayAgainst(this MoveEnum myMove, MoveEnum opponentsMove)
        => myMove switch
        {
            MoveEnum.Rock => opponentsMove switch
            {
                MoveEnum.Scissors => OutcomeEnum.Win,
                MoveEnum.Paper => OutcomeEnum.Lost,
                MoveEnum.Rock => OutcomeEnum.Draw,
                _ => throw new InvalidOperationException($"Wrong opponet's move {opponentsMove}")
            },
            MoveEnum.Paper => opponentsMove switch
            {
                MoveEnum.Rock => OutcomeEnum.Win,
                MoveEnum.Scissors => OutcomeEnum.Lost,
                MoveEnum.Paper => OutcomeEnum.Draw,
                _ => throw new InvalidOperationException($"Wrong opponet's move {opponentsMove}")
            },
            MoveEnum.Scissors => opponentsMove switch
            {
                MoveEnum.Paper => OutcomeEnum.Win,
                MoveEnum.Rock => OutcomeEnum.Lost,
                MoveEnum.Scissors => OutcomeEnum.Draw,
                _ => throw new InvalidOperationException($"Wrong opponet's move {opponentsMove}")
            },
            _ => throw new InvalidOperationException($"Wrong my move {myMove}")
        };
}