using SimulateTheWorld.World;
using SimulateTheWorld.World.Data;

namespace SimulateTheWorld.Start.Models;

public class MainModel
{
    public STWWorld World { get; }

    public MainModel()
    {
        World = STWWorld.Instance;
    }
}