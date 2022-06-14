using System;
using SimulateTheWorld.World.Data.Types.Interfaces;

namespace SimulateTheWorld.World.Data.Types.Classes.Buildings;

public class SettlementCenter : IBuilding
{
    public Action<TerrainTile, TerrainTile>? BuiltModifier => static (currentTile, tileToModify) =>
    {
        currentTile.PopulationValues.Urbanization += 10;
        tileToModify.PopulationValues.Urbanization += 2;
    };

    public Action<TerrainTile, TerrainTile> NextRoundModifier => (currentTile, tileToModify) =>
    {

    };

    public Predicate<TerrainTile> Buildable => static tile => tile.Buildings.Count == 0;
}