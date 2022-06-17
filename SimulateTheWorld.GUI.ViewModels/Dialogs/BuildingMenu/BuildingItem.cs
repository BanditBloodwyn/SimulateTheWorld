using SimulateTheWorld.World.Data.Types.Interfaces;

namespace SimulateTheWorld.GUI.ViewModels.Dialogs.BuildingMenu;

public class BuildingItem
{
    public IBuilding Building { get; }

    public bool Buildable { get; }

    public BuildingItem(IBuilding building, bool buildable)
    {
        Building = building;
        Buildable = buildable;
    }
}