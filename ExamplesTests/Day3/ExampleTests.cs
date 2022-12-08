using Day3;

namespace ExamplesTests.Day3;

public class ExampleTests
{
    [Fact]
    public async Task TestExample1Async()
    {
        //Arrange
        var example1Result = uint.Parse(await File.ReadAllTextAsync(@"Day3\example.output1.txt"));
        Supplies supplies = await Supplies.BuildSuppliesAsync(InputHelpers.GetRucksacksAsyncEnum(@"Day3\example.input.txt"));

        //Act
        uint totalPrioritiesSum = await supplies.CalculateTotalPrioritiesSumAsync();

        //Assert
        Assert.Equal(example1Result, totalPrioritiesSum);
    }
}
