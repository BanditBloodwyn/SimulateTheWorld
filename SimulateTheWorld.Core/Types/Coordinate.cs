namespace SimulateTheWorld.Core.Types;

public struct Coordinate
{
    public int X { get; }

    public int Y { get; }

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public readonly override string ToString()
    {
        return $"{Y}°N {X}°O";
    }
}