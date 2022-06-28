using SimulateTheWorld.World.Systems.FeatureManagement;

namespace SimulateTheWorld.World.Systems.Instances;

public class STWWorld
{
    private readonly FeatureManager _featureManager;

    public STWTerrain Terrain { get; }

    private static STWWorld? _instance;
    public static STWWorld Instance
    {
        get { return _instance ??= new STWWorld(); } 
    }

    private STWWorld()
    {
        Terrain = new STWTerrain();
        _featureManager = new FeatureManager();

        SystemsInitialTrigger();
    }

    public void Update()
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