using System;
using SimulateTheWorld.World.Data.Types.Interfaces;

namespace SimulateTheWorld.World.Data.Types.Classes.Buildings;

public class SettlementCenter : IBuilding
{
    public string Name { get; } = string.Empty;
    public string TypeName => GUI.Resources.Localization.Locals_German.building_typeName_settlementCenter;
    public string Description => GUI.Resources.Localization.Locals_German.building_description_settlementCenter;

    public Action<TerrainTile, TerrainTile, int> BuiltModifier => static (currentTile, tileToModify, surroundingsCount) =>
    {
        currentTile.PopulationValues.Urbanization += 5f / surroundingsCount;
        tileToModify.PopulationValues.Urbanization += 2;
    };

    public Action<TerrainTile, TerrainTile, int> NextRoundModifier => (currentTile, tileToModify, surroundingsCount) =>
    {

    };

    public Predicate<TerrainTile> Buildable => static tile => tile.Buildings.Count == 0;
}