﻿using System.Collections.Generic;
using SimulateTheWorld.World.Data.Data;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.World.Systems.WorldSystems.Helper;

public static class TilesToModifyFinder
{
    public static TerrainTile[] GetTilesToModify(int tileId)
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
            if (id >= STWWorld.Instance.Terrain.Tiles.Length)
                continue;

            tilesToModify.Add(STWWorld.Instance.Terrain.Tiles[id]);
        }

        return tilesToModify.ToArray();
    }
}