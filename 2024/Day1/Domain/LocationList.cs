using Day1.Domain.ValueTypes;

namespace Day1.Domain;
public record LocationList
{
    readonly List<LocationId> locationIds;

    public LocationList(IEnumerable<LocationId> locationIds) => this.locationIds = new(locationIds);

    public static implicit operator List<LocationId>(LocationList locationList) => new(locationList.locationIds);
}
