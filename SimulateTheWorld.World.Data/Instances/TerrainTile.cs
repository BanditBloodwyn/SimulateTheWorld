using SimulateTheWorld.Core.Extentions;
using SimulateTheWorld.World.Data.Data.Container;
using SimulateTheWorld.World.Data.Data.Enums;

namespace SimulateTheWorld.World.Data.Instances;

public class TerrainTile
{
    public int ID { get; set; }

    public TileType TileType { get; set; }
    public TerrainType TerrainType { get; set; }

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

    public void Randomize()
    {
        TileType = TileType.RandomOf();
        TerrainType = TerrainType.RandomOf();
    }
}