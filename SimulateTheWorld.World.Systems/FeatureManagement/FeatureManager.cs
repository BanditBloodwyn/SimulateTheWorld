using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.Core.Reflection;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.World.Systems.FeatureManagement;

public class FeatureManager
{
    private readonly IWorldFeature[] _worldSystems;

    public FeatureManager()
    {
        _worldSystems = TypeGetter.GetInstancesAssignableFromType<IWorldFeature>();
    }

    public void Update(STWWorld world)
    {
        foreach (IWorldFeature feature in _worldSystems)
            feature.Update(world);
    }

    public void NextRoundTrigger(STWWorld world)
    {
        foreach (IWorldFeature feature in _worldSystems)
        {
            Logger.Debug(this, $"Trigger feature {feature.GetType().Name}");
            feature.NextRoundTrigger(world);
        }
    }

    public void InitialTrigger(STWWorld world)
    {
        foreach (IWorldFeature feature in _worldSystems)
        {
            Logger.Debug(this, $"InitialTrigger feature {feature.GetType().Name}");
            feature.InitialTrigger(world);
        }
    }
}