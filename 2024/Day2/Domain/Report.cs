using Day2.Domain.ValueObjects;

namespace Day2.Domain;
public record Report(IEnumerable<Level> Levels)
{
    public bool IsSafe => CalculateSafe(Levels);

    public bool IsToleratedSafe
    {
        get
        {
            if (IsSafe)
            {
                return true;
            }

            List<Level> originalLevels = Levels.ToList();

            for (int levelIndex = 0; levelIndex < originalLevels.Count; levelIndex++)
            {
                List<Level> levelsWithoutCurrent = Levels.ToList();
                levelsWithoutCurrent.RemoveAt(levelIndex);

                if (CalculateSafe(levelsWithoutCurrent))
                {
                    return true;
                }
            }

            return false;
        }
    }

    private static bool CalculateSafe(IEnumerable<Level> levels)
    {
        bool? isReportIncreasing = null;
        Level? previousLevel = null;

        foreach (Level level in levels)
        {
            if (previousLevel is not null)
            {
                isReportIncreasing ??= level > previousLevel;

                switch (isReportIncreasing)
                {
                    case true:
                        if (level < previousLevel + 1 || level > previousLevel + 3)
                        {
                            return false;
                        }
                        break;
                    case false:
                        if (level > previousLevel - 1 || level < previousLevel - 3)
                        {
                            return false;
                        }
                        break;
                }
            }

            previousLevel = level;
        }

        return true;
    }
}
