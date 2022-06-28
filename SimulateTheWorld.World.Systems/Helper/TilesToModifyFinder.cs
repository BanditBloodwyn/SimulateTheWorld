using System.Collections.Generic;
using SimulateTheWorld.World.Data.Data;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.World.Systems.Helper;

public static class TilesToModifyFinder
{
    public static TerrainTile[] GetTilesToModify(int tileId, TerrainTile[] worldTiles)
    {
        List<TerrainTile> tilesToModify = new List<TerrainTile>();

        int[] idsToModify = 
        {
            tileId - WorldProperties.Instance.WorldSize - 1,
            tileId - WorldProperties.Instance.WorldSize,
            tileId - WorldProperties.Instance.WorldSize + 1,
            tileId - 1,
            tileId + 1,
            tileId + WorldProperties.Instance.WorldSize - 1,
            tileId + WorldProperties.Instance.WorldSize,
            tileId + WorldProperties.Instance.WorldSize + 1,
        };

        foreach (int id in idsToModify)
        {
            if (id < 0)
                continue;
            if (id >= worldTiles.Length)
                continue;

            tilesToModify.Add(worldTiles[id]);
        }

        return tilesToModify.ToArray();
    }
}