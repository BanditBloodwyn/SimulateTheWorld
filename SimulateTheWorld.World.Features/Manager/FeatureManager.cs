using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.Core.Reflection;
using SimulateTheWorld.World.Data.Types.Interfaces;
using SimulateTheWorld.World.Data.Types.Interfaces.WorldFeatures;

namespace SimulateTheWorld.World.Features.Manager;

public class FeatureManager
{
    private readonly IWorldFeature[] _worldFeatures;

    public FeatureManager()
    {
        _worldFeatures = TypeGetter.GetInstancesAssignableFromType<IWorldFeature>();
    }

    public void Update(IWorld world)
    {
        foreach (IWorldFeature feature in _worldFeatures)
            feature.Update(world);
    }

    public void NextRoundTrigger(IWorld world)
    {
        foreach (IWorldFeature feature in _worldFeatures)
        {
            Logger.Debug(this, $"Trigger feature {feature.GetType().Name}");
            feature.NextRoundTrigger(world);
        }
    }

    public void InitialTrigger(IWorld world)
    {
        foreach (IWorldFeature feature in _worldFeatures)
        {
            Logger.Debug(this, $"InitialTrigger feature {feature.GetType().Name}");
            feature.InitialTrigger(world);
        }
    }
}