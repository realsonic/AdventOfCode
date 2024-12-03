using static Day2.Dtos.InputRecord;

namespace Day2.Dtos;

public record InputRecord(OpponentsMoveRecordEnum OpponentsMove, MyAnswerRecordEnum MyAnswer)
{
    public static InputRecord BuildFromString(string record)
        => new(
            OpponentsMove: record[0] switch
            {
                'A' => OpponentsMoveRecordEnum.A,
                'B' => OpponentsMoveRecordEnum.B,
                'C' => OpponentsMoveRecordEnum.C,
                _ => throw new InvalidOperationException($"Wrong opponent's move: {record[0]} in record: {record}.")
            },
            MyAnswer: record[2] switch
            {
                'X' => MyAnswerRecordEnum.X,
                'Y' => MyAnswerRecordEnum.Y,
                'Z' => MyAnswerRecordEnum.Z,
                _ => throw new InvalidOperationException($"Wrong my move: {record[2]} in record: {record}.")
            }
        );

    public enum OpponentsMoveRecordEnum { A, B, C }

    public enum MyAnswerRecordEnum { X, Y, Z }
};
