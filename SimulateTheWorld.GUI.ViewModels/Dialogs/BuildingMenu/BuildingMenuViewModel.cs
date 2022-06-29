using System;
using System.Linq;
using System.Reflection;
using SimulateTheWorld.Core.Reflection;
using SimulateTheWorld.GUI.Core.MVVM;
using SimulateTheWorld.World.Core.Helper;
using SimulateTheWorld.World.Data.Types.Classes;
using SimulateTheWorld.World.Data.Types.Interfaces;

namespace SimulateTheWorld.GUI.ViewModels.Dialogs.BuildingMenu;

public class BuildingMenuViewModel : ObservableObject
{
    private TerrainTile? _tile;

    public BuildingItem[]? Buildings { get; private set; }

    public TerrainTile? Tile
    {
        get => _tile;
        set
        {
            _tile = value;
            Buildings = GetAllBuildings();

            OnPropertyChanged();
            OnPropertyChanged(nameof(Buildings));
        }
    }

    private BuildingItem[] GetAllBuildings()
    {
        if(Tile == null)
            return Array.Empty<BuildingItem>();

        IBuilding[] buildings = TypeGetter.GetInstancesAssignableFromType<IBuilding>(Assembly.GetAssembly(typeof(IBuilding)));
        return buildings.Select(building => new BuildingItem(building, building.Buildable(Tile))).ToArray();
    }

    public void Build(Type type)
    {
        BuildingBuilder.Build(type, Tile);
    }
}