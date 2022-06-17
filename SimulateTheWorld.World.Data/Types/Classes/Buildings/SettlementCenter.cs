using System;
using SimulateTheWorld.World.Data.Types.Interfaces;

namespace SimulateTheWorld.World.Data.Types.Classes.Buildings;

public class SettlementCenter : IBuilding
{
    public string? Name { get; }
    public string TypeName => GUI.Resources.Localization.Locals_German.building_typeName_settlementCenter;
    public string Description => GUI.Resources.Localization.Locals_German.building_description_settlementCenter;

    public Action<TerrainTile, TerrainTile> BuiltModifier => static (currentTile, tileToModify) =>
    {
        currentTile.PopulationValues.Urbanization += 10;
        tileToModify.PopulationValues.Urbanization += 2;
    };

    public Action<TerrainTile, TerrainTile> NextRoundModifier => (currentTile, tileToModify) =>
    {

    };

    public Predicate<TerrainTile> Buildable => static tile => tile.Buildings.Count == 0;
}