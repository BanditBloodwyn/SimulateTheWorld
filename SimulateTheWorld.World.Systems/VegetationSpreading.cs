using System;
using SimulateTheWorld.World.Data.Data;
using SimulateTheWorld.World.Data.Types.Classes;
using SimulateTheWorld.World.Data.Types.Enums;
using SimulateTheWorld.World.Systems.Base;

namespace SimulateTheWorld.World.Systems;

public class VegetationSpreading : SurroundingsInfluencingSystem
{
    public VegetationSpreading()
    {
        _modifier = static (currentTile, tileToModify, _) =>
        {
            if (!AllowModification(tileToModify)) 
                return;

            tileToModify.FloraValues.DeciduousTrees = MathF.Min(tileToModify.FloraValues.DeciduousTrees + currentTile.FloraValues.DeciduousTrees * WorldProperties.Instance.VegetationSpreadingSpeed, 100);
            tileToModify.FloraValues.EvergreenTrees = MathF.Min(tileToModify.FloraValues.EvergreenTrees + currentTile.FloraValues.EvergreenTrees * WorldProperties.Instance.VegetationSpreadingSpeed, 100);
        };
    }

    private static bool AllowModification(TerrainTile tileToModify)
    {
        if (tileToModify.TileType == TileType.Water)
            return false;

        if (tileToModify.VegetationType is VegetationType.Alpine_Bushes or VegetationType.Subnivale
            or VegetationType.Nivale)
            return false;

        if (tileToModify.FloraValues.DeciduousTrees + tileToModify.FloraValues.EvergreenTrees >= 100)
            return false;

        return true;
    }
}