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

    public TerrainValues TerrainValues { get; set; }
    public FloraValues FloraValues { get; set; }
    public FaunaValues FaunaValues { get; set; }
    public PopulationValues PopulationValues { get; set; }

    public TerrainTile()
    {
        TerrainValues = new TerrainValues();
        FloraValues = new FloraValues();
        FaunaValues = new FaunaValues();
        PopulationValues = new PopulationValues();
    }
}