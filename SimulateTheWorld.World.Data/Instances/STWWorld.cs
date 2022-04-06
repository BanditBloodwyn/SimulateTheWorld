namespace SimulateTheWorld.World.Data.Instances;

public class STWWorld
{
    public STWTerrain Terrain { get; }

    private static STWWorld? _instance;

    public static STWWorld Instance
    {
        get { return _instance ??= new STWWorld(); } 
    }

    private STWWorld()
    {
        Terrain = new STWTerrain();
        StartWorld();
    }

    private void StartWorld()
    {

    }
}