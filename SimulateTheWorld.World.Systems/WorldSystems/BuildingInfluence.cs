using SimulateTheWorld.World.Data.Types.Interfaces;
using SimulateTheWorld.World.Systems.WorldSystems.Base;

namespace SimulateTheWorld.World.Systems.WorldSystems;

public class BuildingInfluence : SurroundingsInfluencingSystem
{
    public BuildingInfluence()
    {
        _modifier = static (currentTile, tileToModify, surroundingsCount) =>
        {
            foreach (IBuilding building in currentTile.Buildings)
                building.NextRoundModifier?.Invoke(currentTile, tileToModify, surroundingsCount);
        };
    }
}