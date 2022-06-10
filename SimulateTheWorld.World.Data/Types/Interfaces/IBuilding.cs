using System;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.World.Data.Types.Interfaces;

public interface IBuilding
{
    public Action<TerrainTile, TerrainTile>? Modifier { get; set; }
}