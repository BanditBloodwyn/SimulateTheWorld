using SimulateTheWorld.World.Systems.FeatureManagement.Features;

namespace SimulateTheWorld.World.Systems.Instances;

public class STWWorld
{
    private static STWWorld? _instance;

    // FEATURES
    private readonly FeatureManager _featureManager;

    public STWTerrain Terrain { get; }

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