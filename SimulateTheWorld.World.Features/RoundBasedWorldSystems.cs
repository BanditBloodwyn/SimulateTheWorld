using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.World.Data.Types.Interfaces;
using SimulateTheWorld.World.Data.Types.Interfaces.WorldFeatures;
using SimulateTheWorld.World.Data.Types.Interfaces.WorldFeatures.WorldSystems;
using SimulateTheWorld.World.Systems.Manager;

namespace SimulateTheWorld.World.Features;

public class RoundBasedWorldSystems : IRoundBasedWorldFeature
{
    private readonly IWorldSystem[] _worldSystems;

    public RoundBasedWorldSystems()
    {
        _worldSystems = SystemGetter.GetWorldSystems();
    }

    public void NextRoundTrigger(IWorld world)
    {
        foreach (IWorldSystem system in _worldSystems)
        {
            Logger.Debug(this, $"Trigger system {system.GetType().Name}");
            system.Trigger(world);
        }
    }

    public void InitialTrigger(IWorld world)
    {
        foreach (IWorldSystem system in _worldSystems)
        {
            Logger.Debug(this, $"InitialTrigger system {system.GetType().Name}");
            system.InitialTrigger(world);
        }
    }
}