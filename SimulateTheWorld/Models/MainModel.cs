using SimulateTheWorld.World;

namespace SimulateTheWorld.Start.Models;

public class MainModel
{
    public STWWorld World { get; }

    public MainModel()
    {
        World = STWWorld.Instance;
    }
}