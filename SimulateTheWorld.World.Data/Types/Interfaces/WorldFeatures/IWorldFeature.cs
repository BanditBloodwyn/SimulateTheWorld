namespace SimulateTheWorld.World.Data.Types.Interfaces.WorldFeatures;

public interface IWorldFeature
{
    public void Update(IWorld world);

    public void NextRoundTrigger(IWorld world);

    public void InitialTrigger(IWorld world);

}