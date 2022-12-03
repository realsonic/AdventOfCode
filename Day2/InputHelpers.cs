using Day2.Dtos;
using Day2.Model;

using static Day2.Dtos.InputRecord;

namespace Day2;

public class InputHelpers
{
    public static async IAsyncEnumerable<StrategyRecord> GetStrategyRecordsAsync(string inputFilePath)
    {
        await foreach (InputRecord inputRecord in GetInputRecordsAsync(inputFilePath))
            yield return new StrategyRecord(MapOpponentsMove(inputRecord), MapMyAnswer(inputRecord.MyAnswer));
    }

    public static async IAsyncEnumerable<StrategyRecord> GetCorrectStrategyRecordsAsync(string inputFilePath)
    {
        await foreach (InputRecord inputRecord in GetInputRecordsAsync(inputFilePath))
        {
            MoveEnum opponentsMove = MapOpponentsMove(inputRecord);
            MoveEnum myMove = MapCorrectMyAnswer(inputRecord.MyAnswer, opponentsMove);
            yield return new StrategyRecord(opponentsMove, myMove);
        }
    }

    private static async IAsyncEnumerable<InputRecord> GetInputRecordsAsync(string inputFilePath)
    {
        await foreach (string record in File.ReadLinesAsync(inputFilePath))
            yield return BuildFromString(record);
    }

    private static MoveEnum MapOpponentsMove(InputRecord inputRecord)
        => inputRecord.OpponentsMove switch
        {
            OpponentsMoveRecordEnum.A => MoveEnum.Rock,
            OpponentsMoveRecordEnum.B => MoveEnum.Paper,
            OpponentsMoveRecordEnum.C => MoveEnum.Scissors,
            _ => throw new InvalidOperationException($"Wrong input record's opponent's move {inputRecord.OpponentsMove} in record: {inputRecord}.")
        };

    private static MoveEnum MapMyAnswer(MyAnswerRecordEnum myAnswer)
        => myAnswer switch
        {
            MyAnswerRecordEnum.X => MoveEnum.Rock,
            MyAnswerRecordEnum.Y => MoveEnum.Paper,
            MyAnswerRecordEnum.Z => MoveEnum.Scissors,
            _ => throw new InvalidOperationException($"Wrong input record's my answer {myAnswer}.")
        };

    private static MoveEnum MapCorrectMyAnswer(MyAnswerRecordEnum myAnswer, MoveEnum opponentsMove)
        => myAnswer switch
        {
            MyAnswerRecordEnum.X => opponentsMove.GetLoser(),
            MyAnswerRecordEnum.Y => opponentsMove.GetDraw(),
            MyAnswerRecordEnum.Z => opponentsMove.GetWinner(),
            _ => throw new InvalidOperationException($"Wrong input record's my answer {myAnswer}.")
        };
}
