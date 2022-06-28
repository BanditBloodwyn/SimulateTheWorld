using SimulateTheWorld.Core.Reflection;
using SimulateTheWorld.World.Data.Types.Interfaces.WorldFeatures.WorldSystems;

namespace SimulateTheWorld.World.Systems.Manager;

public static class SystemGetter
{
    public static IWorldSystem[] GetWorldSystems()
    {
        return TypeGetter.GetInstancesAssignableFromType<IWorldSystem>();
    }
}