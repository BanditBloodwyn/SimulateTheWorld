using System.Collections.Generic;
using SimulateTheWorld.Core.Types;
using SimulateTheWorld.World.Data.Types.Container;
using SimulateTheWorld.World.Data.Types.Enums;
using SimulateTheWorld.World.Data.Types.Interfaces;

namespace SimulateTheWorld.World.Data.Types.Classes;

public class TerrainTile
{
    public int ID { get; set; }

    public Location? Location { get; set; }

    public bool Marked { get; set; }
    public bool Pinned { get; set; }

    public TileType TileType { get; set; }
    public VegetationType VegetationType { get; set; }

    public TerrainValues TerrainValues { get; } = new();
    public FloraValues FloraValues { get; } = new();
    public FaunaValues FaunaValues { get; } = new();
    public PopulationValues PopulationValues { get; } = new();

    public List<IBuilding> Buildings { get; } = new();
}