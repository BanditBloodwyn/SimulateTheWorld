using System;
using SimulateTheWorld.World.Data.Types.Classes;
using SimulateTheWorld.World.Systems.Instances;
using SimulateTheWorld.World.Systems.WorldSystems.Helper;

namespace SimulateTheWorld.World.Systems.WorldSystems.Base;

public abstract class SurroundingsInfluencingSystem : IWorldSystem
{
    /// <summary>
    /// Modifier function
    /// First tile is current tile, second is tile to modify
    /// </summary>
    protected Action<TerrainTile, TerrainTile, int>? _modifier;

    public void InitialTrigger()
    {

    }

    public void Trigger()
    {
        if (_modifier == null) 
            return;

        TerrainTile[] tiles = STWWorld.Instance.Terrain.Tiles;

        foreach (TerrainTile currentTile in tiles)
        {
            TerrainTile[] tilesToModify = TilesToModifyFinder.GetTilesToModify(currentTile.ID);

            foreach (TerrainTile tileToModify in tilesToModify)
                _modifier.Invoke(currentTile, tileToModify, tilesToModify.Length);
        }
    }
}