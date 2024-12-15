using Day1.Domain;
using Day1.Domain.ValueTypes;

namespace Day1;
public static class InputHelpers
{
    public static async Task<ListComparision> LoadListComparisonFromFile(string inputFilePath)
    {
        List<uint> leftList = [], rightList = [];

        await foreach (string record in File.ReadLinesAsync(inputFilePath))
        {
            string[] numbersStrings = record.Split("   ");
            if (numbersStrings.Length != 2) throw new InvalidOperationException($"Запись (\"{record}\") должна состоять из 2х элементов, разделённых тремя пробелами");

            if (uint.TryParse(numbersStrings[0], out uint leftNumber)) leftList.Add(leftNumber);
            else throw new InvalidOperationException($"Левый элемент записи ({numbersStrings[0]}) должен быть положительным числом");

            if (uint.TryParse(numbersStrings[1], out uint rightNumber)) rightList.Add(rightNumber);
            else throw new InvalidOperationException($"Левый элемент записи ({numbersStrings[1]}) должен быть положительным числом");
        }

        return new ListComparision(leftList.ToLocationList(), rightList.ToLocationList());
    }

    private static LocationList ToLocationList(this List<uint> numberList) => new(numberList.Select(number => new LocationId(number)));
}
