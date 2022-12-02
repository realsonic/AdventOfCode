namespace Day2.Dtos;

public record InputRecord(OpponentsMoveEnum OpponentsMove, MyAnswerEnum MyAnswer)
{
    public static InputRecord BuildFromString(string record)
        => new(
            OpponentsMove: record[0] switch
            {
                'A' => OpponentsMoveEnum.A,
                'B' => OpponentsMoveEnum.B,
                'C' => OpponentsMoveEnum.C,
                _ => throw new InvalidOperationException($"Wrong opponent's move: {record[0]} in record: {record}.")
            },
            MyAnswer: record[2] switch
            {
                'X' => MyAnswerEnum.X,
                'Y' => MyAnswerEnum.Y,
                'Z' => MyAnswerEnum.Z,
                _ => throw new InvalidOperationException($"Wrong my move: {record[2]} in record: {record}.")
            }
        );
};
