using SimulateTheWorld.Core.Types;

namespace SimulateTheWorld.World.Data.Types.Classes;

public class Location
{
    public string Name { get; }

    public Coordinate Coordinate { get; }

    public Location(string name, Coordinate coordinate)
    {
        Name = name;
        Coordinate = coordinate;
    }
}