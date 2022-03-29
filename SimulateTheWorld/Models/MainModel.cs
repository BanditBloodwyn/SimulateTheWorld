using SimulateTheWorld.World;

namespace SimulateTheWorld.Start.Models;

public class MainModel
{
    public STWWorld World { get; private set; }

    public MainModel()
    {
        CreateWorld();
    }

    private void CreateWorld()
    {
        World = STWWorld.Instance;
    }
}