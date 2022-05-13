using System.Diagnostics;

namespace SimulateTheWorld.World.System.Instances;

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
    }

    public void Update()
    {
        Debug.WriteLine("Update world");

        // Debugging
        RandomizeTiles();
    }

    private void RandomizeTiles()
    {
        Terrain.RandomizeTiles();
    }
}