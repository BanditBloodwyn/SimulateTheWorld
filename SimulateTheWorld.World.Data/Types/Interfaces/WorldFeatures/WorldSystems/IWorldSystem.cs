namespace SimulateTheWorld.World.Data.Types.Interfaces.WorldFeatures.WorldSystems;

public interface IWorldSystem
{
    public void InitialTrigger(IWorld world);

    public void Trigger(IWorld world);
}