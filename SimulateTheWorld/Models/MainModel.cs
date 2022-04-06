using SimulateTheWorld.World.Data;
using SimulateTheWorld.World.Data.Instances;

namespace SimulateTheWorld.Start.Models;

public class MainModel
{
    public STWWorld World { get; }

    public MainModel()
    {
        World = STWWorld.Instance;
    }
}