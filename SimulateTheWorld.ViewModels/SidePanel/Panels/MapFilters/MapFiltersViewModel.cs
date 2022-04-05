using SimulateTheWorld.Core.MVVM;
using SimulateTheWorld.Models.SidePanel.Panels.MapFilters;

namespace SimulateTheWorld.GUI.ViewModels.SidePanel.Panels.MapFilters;

public class MapFiltersViewModel : ObservableObject
{
    public MapFiltersModel Model { get; }

    public MapFiltersViewModel()
    {
        Model = new MapFiltersModel();
    }
}