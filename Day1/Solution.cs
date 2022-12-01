namespace Day1;

public class Solution
{
    public Solution(IAsyncEnumerable<string> input)
    {
        this.input = input;
    }

    public ValueTask<int> MaxCaloriesPerElf
    {
        get
        {
            maxCaloriesPerElfLazyAsyncResult ??= new(CalculateMaxCaloriesPerElfAsync);
            return maxCaloriesPerElfLazyAsyncResult.Value;
        }
    }

    public ValueTask<int> TotalCaloriesFromTop3Elves
    {
        get
        {
            totalCaloriesFromTop3ElvesLazyAsyncResult ??= new(CalculateTotalCaloriesFromTop3ElvesAsync);
            return totalCaloriesFromTop3ElvesLazyAsyncResult.Value;
        }
    }

    public event Action<int>? OnSnackCounted;
    public event Action<int>? OnElfCounted;

    private Lazy<ValueTask<int>>? maxCaloriesPerElfLazyAsyncResult;

    private async ValueTask<int> CalculateMaxCaloriesPerElfAsync()
        => await EnumerateElvesCaloriesAsync().MaxAsync();

    private Lazy<ValueTask<int>>? totalCaloriesFromTop3ElvesLazyAsyncResult;

    private async ValueTask<int> CalculateTotalCaloriesFromTop3ElvesAsync()
        => await EnumerateElvesCaloriesAsync().OrderByDescending(calories => calories).Take(3).SumAsync();

    private async IAsyncEnumerable<int> EnumerateElvesCaloriesAsync()
    {
        int currentElfCalories = 0;
        int snacksCounted = 0;
        int elvesCounted = 0;
        await foreach (var snackRecord in input)
        {
            if (!string.IsNullOrEmpty(snackRecord))
            {
                var snackCalories = int.Parse(snackRecord);
                currentElfCalories += snackCalories;
                OnSnackCounted?.Invoke(++snacksCounted);
            }
            else
            {
                OnElfCounted?.Invoke(++elvesCounted);
                yield return currentElfCalories;
                currentElfCalories = 0;
            }
        }
        OnElfCounted?.Invoke(++elvesCounted);
        yield return currentElfCalories;
    }

    private readonly IAsyncEnumerable<string> input;
}