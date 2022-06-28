using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.World.Data.Types.Interfaces;

public interface ITerrain
{
    public TerrainTile[] Tiles { get; }
}