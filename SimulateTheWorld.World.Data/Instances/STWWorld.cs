using System.Data;
using System.Threading.Tasks;

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
        Task.Factory.StartNew(Update);
    }

    private void Update()
    {
        while(true)
        {
            // Debugging
            RandomizeTiles();
        }
    }

    private void RandomizeTiles()
    {
        Terrain.RandomizeTiles();
    }
}