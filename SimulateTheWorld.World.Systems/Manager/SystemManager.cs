using SimulateTheWorld.Core.Reflection;
using SimulateTheWorld.World.Data.Types.Interfaces.WorldFeatures.WorldSystems;

namespace SimulateTheWorld.World.Systems.Manager;

public static class SystemManager
{
    public static IWorldSystem[] GetWorldSystems()
    {
        return TypeGetter.GetInstancesAssignableFromType<IWorldSystem>();
    }
}