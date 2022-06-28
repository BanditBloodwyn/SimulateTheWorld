using System.Threading.Tasks;
using SimulateTheWorld.World.Core.Helper;
using SimulateTheWorld.World.Data.Types.Interfaces;
using SimulateTheWorld.World.Features.Manager;

namespace SimulateTheWorld.World.Core;

public class STWWorld : IWorld
{
    private readonly FeatureManager _featureManager;

    public ITerrain Terrain { get; }

    public TileMarker TileMarker { get; }


    private static STWWorld? _instance;
    public static STWWorld Instance
    {
        get { return _instance ??= new STWWorld(); } 
    }

    private STWWorld()
    {
        Terrain = new STWTerrain();
        TileMarker = new TileMarker();

        _featureManager = new FeatureManager();

        Task.Factory
            .StartNew(() =>
            {
                while (true)
                    Update();
            });

        SystemsInitialTrigger();
    }

    private void Update()
    {
        _featureManager.Update(this);
    }

    public void NextRoundTrigger()
    {
        _featureManager.NextRoundTrigger(this);
    }

    private void SystemsInitialTrigger()
    {
        _featureManager.InitialTrigger(this);
    }
}