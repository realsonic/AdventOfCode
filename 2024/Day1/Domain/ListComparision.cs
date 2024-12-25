using Day1.Domain.ValueObjects;

namespace Day1.Domain;
public record ListComparision(LocationList LeftList, LocationList RightList)
{
    public long TotalDistance
    {
        get
        {
            long totalDistance = 0;

            List<LocationId> leftListRemainIds = new(LeftList);
            List<LocationId> rightListRemainIds = new(RightList);

            while (leftListRemainIds.Count > 0 && rightListRemainIds.Count > 0)
            {
                LocationId minLeftLocationId = leftListRemainIds.Min() ?? throw new InvalidOperationException("Неожиданно не найден минимум в левом списке");
                LocationId minRightLocationId = rightListRemainIds.Min() ?? throw new InvalidOperationException("Неожиданно не найден минимум в правом списке");

                long distance = Math.Abs((long)minLeftLocationId - minRightLocationId);
                totalDistance += distance;

                leftListRemainIds.Remove(minLeftLocationId);
                rightListRemainIds.Remove(minRightLocationId);
            }

            return totalDistance;
        }
    }

    public long SimilarityScore
    {
        get
        {
            long similarityScore = 0;

            foreach (LocationId leftLocationId in LeftList)
            {
                similarityScore += leftLocationId * RightList.Count(locationId => locationId == leftLocationId);
            }

            return similarityScore;
        }
    }
}
