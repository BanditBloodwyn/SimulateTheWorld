namespace SimulateTheWorld.World.Data.Data;

public class WorldProperties
{
    private static WorldProperties? _instance;

    public int WorldSize { get; set; }
    public float TileSize { get; set; }

    public static WorldProperties Instance
    {
        get { return _instance ??= new WorldProperties(); }
    }

    private WorldProperties()
    {
        WorldSize = 500; 
        TileSize = 0.1f;
    }
}