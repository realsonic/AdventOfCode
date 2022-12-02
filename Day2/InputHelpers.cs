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
                    OpponentsMoveEnum.A => MoveEnum.Rock,
                    OpponentsMoveEnum.B => MoveEnum.Paper,
                    OpponentsMoveEnum.C => MoveEnum.Scissors,
                    _ => throw new InvalidOperationException($"Wrong input record's opponent's move {inputRecord.OpponentsMove} in record: {inputRecord}.")
                },
                MyMove: inputRecord.MyAnswer switch
                {
                    MyAnswerEnum.X => MoveEnum.Rock,
                    MyAnswerEnum.Y => MoveEnum.Paper,
                    MyAnswerEnum.Z => MoveEnum.Scissors,
                    _ => throw new InvalidOperationException($"Wrong input record's my answer {inputRecord.MyAnswer} in record: {inputRecord}.")
                }
            );
    }

    public static async IAsyncEnumerable<StrategyRecord> GetCorrectStrategyRecordsAsync(string inputFilePath)
    {
        await foreach (InputRecord inputRecord in GetInputRecordsAsync(inputFilePath))
        {
            MoveEnum opponentsMove = inputRecord.OpponentsMove switch
            {
                OpponentsMoveEnum.A => MoveEnum.Rock,
                OpponentsMoveEnum.B => MoveEnum.Paper,
                OpponentsMoveEnum.C => MoveEnum.Scissors,
                _ => throw new InvalidOperationException($"Wrong input record's opponent's move {inputRecord.OpponentsMove} in record: {inputRecord}.")
            };

            MoveEnum myMove = inputRecord.MyAnswer switch
            {
                MyAnswerEnum.X => opponentsMove.GetLoser(),
                MyAnswerEnum.Y => opponentsMove.GetDraw(),
                MyAnswerEnum.Z => opponentsMove.GetWinner(),
                _ => throw new InvalidOperationException($"Wrong input record's my answer {inputRecord.MyAnswer} in record: {inputRecord}.")
            };

            yield return new StrategyRecord(opponentsMove, myMove);
        }
    }

    private static async IAsyncEnumerable<InputRecord> GetInputRecordsAsync(string inputFilePath)
    {
        await foreach (string record in File.ReadLinesAsync(inputFilePath))
            yield return InputRecord.BuildFromString(record);
    }
}
