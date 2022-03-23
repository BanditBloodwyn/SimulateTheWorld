using System.Collections.ObjectModel;
using SimulateTheWorld.Models.Core;

namespace SimulateTheWorld.Models.SidePanel.Panels.MapFilters;

public class MapFiltersViewModel : BaseViewModel
{
    public ObservableCollection<MapFilter> MapFilters { get; }

    public MapFiltersViewModel()
    {
        MapFilters = new ObservableCollection<MapFilter>();
        InitializeMapFilters();
    }

    private void InitializeMapFilters()
    {
        MapFilters.Add(new MapFilter("Population by tribe", true));
        MapFilters.Add(new MapFilter("Countries"));
        MapFilters.Add(new MapFilter("Life standard"));
        MapFilters.Add(new MapFilter("Urbanization"));
    }
}