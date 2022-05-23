using System.Diagnostics;

namespace SimulateTheWorld.World.Systems.Instances;

public class STWWorld
{
    public const int TerrainSize = 2000;
    public const float TileSize = 0.1f;

    public STWTerrain Terrain { get; }

    private static STWWorld? _instance;

    public static STWWorld Instance
    {
        get { return _instance ??= new STWWorld(); } 
    }

    private STWWorld()
    {
        Terrain = new STWTerrain();
    }

    public void Update()
    {
        Debug.WriteLine("Update world");
    }
}