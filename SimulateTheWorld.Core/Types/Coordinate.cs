namespace SimulateTheWorld.Core.Types;

public struct Coordinate
{
    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public Coordinate(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public readonly override string ToString()
    {
        return $"{Latitude}°N {Longitude}°O";
    }
}