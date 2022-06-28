using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.World.Systems.WorldSystems.Base;

public interface IWorldSystem
{
    public void InitialTrigger(STWWorld world);

    public void Trigger(STWWorld world);
}