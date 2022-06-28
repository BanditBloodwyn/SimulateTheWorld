using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.World.Systems.FeatureManagement;

public interface IWorldFeature
{
    public void Update(STWWorld world);

    public void NextRoundTrigger(STWWorld world);

    public void InitialTrigger(STWWorld world);

}