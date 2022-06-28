using System;
using SimulateTheWorld.World.Data.Types.Classes;
using SimulateTheWorld.World.Data.Types.Interfaces;
using SimulateTheWorld.World.Data.Types.Interfaces.WorldFeatures.WorldSystems;
using SimulateTheWorld.World.Systems.Helper;

namespace SimulateTheWorld.World.Systems.Base;

public abstract class SurroundingsInfluencingSystem : IWorldSystem
{
    /// <summary>
    /// Modifier function
    /// First tile is current tile, second is tile to modify
    /// </summary>
    protected Action<TerrainTile, TerrainTile, int>? _modifier;

    public void InitialTrigger(IWorld world)
    {

    }

    public void Trigger(IWorld world)
    {
        if (_modifier == null) 
            return;

        foreach (TerrainTile currentTile in world.Terrain.Tiles)
        {
            TerrainTile[] tilesToModify = TilesToModifyFinder.GetTilesToModify(currentTile.ID, world.Terrain.Tiles);

            foreach (TerrainTile tileToModify in tilesToModify)
                _modifier.Invoke(currentTile, tileToModify, tilesToModify.Length);
        }
    }
}