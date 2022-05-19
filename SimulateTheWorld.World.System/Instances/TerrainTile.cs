using SimulateTheWorld.World.Data.Data.Container;
using SimulateTheWorld.World.Data.Data.Enums;
using SimulateTheWorld.World.Data.Data.Types;

namespace SimulateTheWorld.World.System.Instances;

public class TerrainTile
{
    public int ID { get; set; }

    public Location? Location { get; set; }

    public bool Marked { get; set; }

    public TileType TileType { get; set; }
    public VegetationType VegetationType { get; set; }

    public TerrainValues TerrainValues { get; set; } = new();
    public FloraValues FloraValues { get; set; } = new();
    public FaunaValues FaunaValues { get; set; } = new();
    public PopulationValues PopulationValues { get; set; } = new();
}