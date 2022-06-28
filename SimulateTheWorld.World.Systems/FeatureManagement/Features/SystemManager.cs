using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.Core.Reflection;
using SimulateTheWorld.World.Systems.Instances;
using SimulateTheWorld.World.Systems.WorldSystems.Base;

namespace SimulateTheWorld.World.Systems.FeatureManagement.Features;

public class SystemManager : IWorldFeature
{
    private readonly IWorldSystem[] _worldSystems;

    public SystemManager()
    {
        _worldSystems = TypeGetter.GetInstancesAssignableFromType<IWorldSystem>();
    }

    public void Update(STWWorld world)
    {

    }

    public void NextRoundTrigger(STWWorld world)
    {
        foreach (IWorldSystem system in _worldSystems)
        {
            Logger.Debug(this, $"Trigger system {system.GetType().Name}");
            system.Trigger(world);
        }
    }

    public void InitialTrigger(STWWorld world)
    {
        foreach (IWorldSystem system in _worldSystems)
        {
            Logger.Debug(this, $"InitialTrigger system {system.GetType().Name}");
            system.InitialTrigger(world);
        }
    }
}