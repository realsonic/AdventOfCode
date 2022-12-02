using Day2.Dtos;
using Day2.Model;

namespace Day2;

public class InputHelpers
{
    public static async IAsyncEnumerable<StrategyRecord> GetStrategyRecordsAsync(string inputFilePath)
    {
        await foreach (InputRecord inputRecord in GetInputRecordsAsync(inputFilePath))
            yield return new StrategyRecord(
                OpponentsMove: inputRecord.OpponentsMove switch
                {
                    InputRecord.OpponentsMoveEnum.A_Rock => MoveEnum.Rock,
                    InputRecord.OpponentsMoveEnum.B_Paper => MoveEnum.Paper,
                    InputRecord.OpponentsMoveEnum.C_Scissors => MoveEnum.Scissors,
                    _ => throw new InvalidOperationException($"Wrong input record's opponent's move {inputRecord.OpponentsMove} in record: {inputRecord}.")
                },
                MyMove: inputRecord.MyMove switch
                {
                    InputRecord.MyMoveEnum.X_Rock => MoveEnum.Rock,
                    InputRecord.MyMoveEnum.Y_Paper => MoveEnum.Paper,
                    InputRecord.MyMoveEnum.Z_Scissors => MoveEnum.Scissors,
                    _ => throw new InvalidOperationException($"Wrong input record's my move {inputRecord.MyMove} in record: {inputRecord}.")
                }
            );
    }

    private static async IAsyncEnumerable<InputRecord> GetInputRecordsAsync(string inputFilePath)
    {
        await foreach (string record in File.ReadLinesAsync(inputFilePath))
            yield return InputRecord.BuildFromString(record);
    }
}
