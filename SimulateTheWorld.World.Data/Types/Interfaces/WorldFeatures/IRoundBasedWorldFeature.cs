namespace SimulateTheWorld.World.Data.Types.Interfaces.WorldFeatures;

public interface IRoundBasedWorldFeature
{
    public void NextRoundTrigger(IWorld world);

    public void InitialTrigger(IWorld world);

}