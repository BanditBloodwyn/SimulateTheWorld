using System;
using SimulateTheWorld.World.Data.Data.Enums;
using SimulateTheWorld.World.Systems.WorldSystems.Base;

namespace SimulateTheWorld.World.Systems.WorldSystems;

public class VegetationSpreading : SurroundingsInfluencingSystem
{
    public VegetationSpreading()
    {
        _modifier = (currentTile, tileToModify) =>
        {
            if(tileToModify.TileType == TileType.Water)
                return;

            if (tileToModify.VegetationType 
                is VegetationType.Alpine_Bushes 
                or VegetationType.Subnivale 
                or VegetationType.Nivale)
                return;

            if (tileToModify.FloraValues.DeciduousTrees + tileToModify.FloraValues.EvergreenTrees >= 100)
                return;

            tileToModify.FloraValues.DeciduousTrees = MathF.Min(tileToModify.FloraValues.DeciduousTrees + currentTile.FloraValues.DeciduousTrees * 0.02f, 100);
            tileToModify.FloraValues.EvergreenTrees = MathF.Min(tileToModify.FloraValues.EvergreenTrees + currentTile.FloraValues.EvergreenTrees * 0.02f, 100);
        };
    }
}