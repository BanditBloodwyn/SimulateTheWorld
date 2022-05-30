namespace SimulateTheWorld.World.Data.Data;

public class WorldProperties
{
    private static WorldProperties? _instance;

    public int WorldSize { get; set; }
    public float TileTotalSize { get; set; }
    public float TileFillSize { get; set; }

    public static WorldProperties Instance
    {
        get { return _instance ??= new WorldProperties(); }
    }

    private WorldProperties()
    {
        WorldSize = 500; 
        TileTotalSize = 0.1f;
        TileFillSize = 0.1f;
    }
}