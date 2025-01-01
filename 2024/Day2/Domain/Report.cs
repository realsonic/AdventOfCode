using Day2.Domain.ValueObjects;

namespace Day2.Domain;
public record Report(IEnumerable<Level> Levels)
{
    public bool IsSafe
    {
        get
        {
            bool? isReportIncreasing = null;
            Level? previousLevel = null;

            foreach (Level level in Levels)
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
}
