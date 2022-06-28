using SimulateTheWorld.World.Systems.Features;

namespace SimulateTheWorld.World.Systems.Instances;

public class STWWorld
{
    private static STWWorld? _instance;

    // FEATURES
    private readonly SystemManager _systemManager;

    public STWTerrain Terrain { get; }

    public static STWWorld Instance
    {
        get { return _instance ??= new STWWorld(); } 
    }

    private STWWorld()
    {
        Terrain = new STWTerrain();
        _systemManager = new SystemManager();

        SystemsInitialTrigger();
    }

    public void Update()
    {
        _systemManager.Trigger(this);
    }

    private void SystemsInitialTrigger()
    {
        _systemManager.InitialTrigger(this);
    }
}