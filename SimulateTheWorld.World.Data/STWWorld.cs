using System.Threading.Tasks;

namespace SimulateTheWorld.World.Data;

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
        Task.Factory.StartNew(() =>
        {
            while (true)
            {
                UpdateWorld();
            }
        });
    }

    private void UpdateWorld()
    {
        ;
    }
}