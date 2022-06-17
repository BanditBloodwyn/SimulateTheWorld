using System;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.World.Data.Types.Interfaces;

public interface IBuilding
{
    public string Name { get; }
    public string TypeName { get; }
    public string Description { get; }
    
    public Action<TerrainTile, TerrainTile>? BuiltModifier { get; }

    public Action<TerrainTile, TerrainTile>? NextRoundModifier { get; }

    public Predicate<TerrainTile> Buildable { get; }
}