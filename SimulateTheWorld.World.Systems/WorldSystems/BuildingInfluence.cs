﻿using SimulateTheWorld.World.Data.Types.Interfaces;
using SimulateTheWorld.World.Systems.WorldSystems.Base;

namespace SimulateTheWorld.World.Systems.WorldSystems;

public class BuildingInfluence : SurroundingsInfluencingSystem
{
    public BuildingInfluence()
    {
        _modifier = static (currentTile, tileToModify) =>
        {
            foreach (IBuilding building in currentTile.Buildings)
                building.Modifier?.Invoke(currentTile, tileToModify);
        };
    }
}