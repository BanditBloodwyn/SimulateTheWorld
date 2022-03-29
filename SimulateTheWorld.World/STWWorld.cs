namespace SimulateTheWorld.World;

public class STWWorld
{
    private static STWWorld? _instance;

    public static STWWorld Instance
    {
        get { return _instance ??= new STWWorld(); } 
    }

    private STWWorld()
    {
        Terrain = new STWTerrain();
    }

    public STWTerrain Terrain { get; }
}