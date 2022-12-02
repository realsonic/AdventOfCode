using static Day2.Dtos.InputRecord;

namespace Day2.Dtos;

public record InputRecord(OpponentsMoveEnum OpponentsMove, MyMoveEnum MyMove)
{
    public static InputRecord BuildFromString(string record)
        => new(
            OpponentsMove: record[0] switch
            {
                'A' => OpponentsMoveEnum.A_Rock,
                'B' => OpponentsMoveEnum.B_Paper,
                'C' => OpponentsMoveEnum.C_Scissors,
                _ => throw new InvalidOperationException($"Wrong opponent's move: {record[0]} in record: {record}.")
            },
            MyMove: record[2] switch
            {
                'X' => MyMoveEnum.X_Rock,
                'Y' => MyMoveEnum.Y_Paper,
                'Z' => MyMoveEnum.Z_Scissors,
                _ => throw new InvalidOperationException($"Wrong my move: {record[2]} in record: {record}.")
            }
        );

    public enum OpponentsMoveEnum { A_Rock, B_Paper, C_Scissors }

    public enum MyMoveEnum { X_Rock, Y_Paper, Z_Scissors }
};
