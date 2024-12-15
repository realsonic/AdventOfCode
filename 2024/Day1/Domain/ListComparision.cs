using Day1.Domain.ValueTypes;

namespace Day1.Domain;
public record ListComparision(LocationList LeftList, LocationList RightList)
{
    public long TotalDistance
    {
        get
        {
            long totalDistance = 0;

            List<LocationId> leftListRemainIds = LeftList;
            List<LocationId> rightListRemainIds = RightList;

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
}
