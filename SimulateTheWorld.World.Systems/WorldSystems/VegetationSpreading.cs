using System.Collections.Generic;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.World.Systems.WorldSystems;

public class VegetationSpreading : IWorldSystem
{
    public void Trigger()
    {
        TerrainTile[] tiles = STWWorld.Instance.Terrain.Tiles;

        foreach (TerrainTile tile in tiles)
        {
            TerrainTile[] tilesToModify = GetTilesToModify(tile.ID);

            foreach (TerrainTile tileToModify in tilesToModify)
            {
                tileToModify.FloraValues.DeciduousTrees += tile.FloraValues.DeciduousTrees * 0.2f;
                tileToModify.FloraValues.EvergreenTrees += tile.FloraValues.EvergreenTrees * 0.2f;
            }
        }
    }

    private TerrainTile[] GetTilesToModify(int tileId)
    {
        List<TerrainTile> tilesToModify = new List<TerrainTile>();

        int[] idsToModify = new[]
        {
            tileId - STWWorld.TerrainSize - 1,
            tileId - STWWorld.TerrainSize,
            tileId - STWWorld.TerrainSize + 1,
            tileId - 1,
            tileId + 1,
            tileId + STWWorld.TerrainSize - 1,
            tileId + STWWorld.TerrainSize,
            tileId + STWWorld.TerrainSize + 1,
        };

        foreach (int id in idsToModify)
        {
            if(id < 0)
                continue;
            if(id > STWWorld.Instance.Terrain.Tiles.Length)
                continue;

            tilesToModify.Add(STWWorld.Instance.Terrain.Tiles[id]);
        }

        return tilesToModify.ToArray();
    }
}