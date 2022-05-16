using SimulateTheWorld.Core.Types;

namespace SimulateTheWorld.World.Data.Data.Types;

public class Location
{
    public string Name { get; set; }

    public Coordinate Coordinate { get; set; }

    public Location(string name, Coordinate coordinate)
    {
        Name = name;
        Coordinate = coordinate;
    }
}