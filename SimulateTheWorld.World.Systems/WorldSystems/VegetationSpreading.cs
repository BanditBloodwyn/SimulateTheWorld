using System;
using SimulateTheWorld.World.Systems.Instances;
using SimulateTheWorld.World.Systems.WorldSystems.Base;
using SimulateTheWorld.World.Systems.WorldSystems.Helper;

namespace SimulateTheWorld.World.Systems.WorldSystems;

public class VegetationSpreading : IWorldSystem
{
    public void Trigger()
    {
        TerrainTile[] tiles = STWWorld.Instance.Terrain.Tiles;

        foreach (TerrainTile tile in tiles)
        {
            TerrainTile[] tilesToModify = TilesToModifyFinder.GetTilesToModify(tile.ID);

            foreach (TerrainTile tileToModify in tilesToModify)
            {
                tileToModify.FloraValues.DeciduousTrees = MathF.Min(tileToModify.FloraValues.DeciduousTrees + tile.FloraValues.DeciduousTrees * 0.02f, 100);  
                tileToModify.FloraValues.EvergreenTrees = MathF.Min(tileToModify.FloraValues.EvergreenTrees + tile.FloraValues.EvergreenTrees * 0.02f, 100);
            }
        }
    }
}