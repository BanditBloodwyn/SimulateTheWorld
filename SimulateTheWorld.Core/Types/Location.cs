namespace SimulateTheWorld.Core.Types;

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