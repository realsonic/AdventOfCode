using Day1.Domain.ValueTypes;

using System.Collections;

namespace Day1.Domain;
public record LocationList : IEnumerable<LocationId>
{
    readonly List<LocationId> locationIds;

    public LocationList(IEnumerable<LocationId> locationIds) => this.locationIds = new(locationIds);

    IEnumerator<LocationId> IEnumerable<LocationId>.GetEnumerator() => locationIds.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => locationIds.GetEnumerator();
}
