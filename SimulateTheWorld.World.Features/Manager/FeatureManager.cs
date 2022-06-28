using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.Core.Reflection;
using SimulateTheWorld.World.Data.Types.Interfaces;
using SimulateTheWorld.World.Data.Types.Interfaces.WorldFeatures;

namespace SimulateTheWorld.World.Features.Manager;

public class FeatureManager
{
    private readonly IRoundBasedWorldFeature[] _worldFeatures;
    private readonly IRealtimeWorldFeature[] _realtimeWorldFeatures;

    public FeatureManager()
    {
        _worldFeatures = TypeGetter.GetInstancesAssignableFromType<IRoundBasedWorldFeature>();
        _realtimeWorldFeatures = TypeGetter.GetInstancesAssignableFromType<IRealtimeWorldFeature>();
    }

    public void Update(IWorld world)
    {
        foreach (IRealtimeWorldFeature feature in _realtimeWorldFeatures)
            feature.Update(world);
    }

    public void NextRoundTrigger(IWorld world)
    {
        foreach (IRoundBasedWorldFeature feature in _worldFeatures)
        {
            Logger.Debug(this, $"Trigger feature {feature.GetType().Name}");
            feature.NextRoundTrigger(world);
        }
    }

    public void InitialTrigger(IWorld world)
    {
        foreach (IRoundBasedWorldFeature feature in _worldFeatures)
        {
            Logger.Debug(this, $"InitialTrigger feature {feature.GetType().Name}");
            feature.InitialTrigger(world);
        }
    }
}