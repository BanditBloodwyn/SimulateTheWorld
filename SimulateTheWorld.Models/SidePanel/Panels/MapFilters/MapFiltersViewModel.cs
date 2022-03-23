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
        MapFilters.Add(new MapFilter(Resources.Localization.Locals_German.mapfilters_popByTribe, true));
        MapFilters.Add(new MapFilter(Resources.Localization.Locals_German.mapfilters_countries));
        MapFilters.Add(new MapFilter(Resources.Localization.Locals_German.mapfilters_lifeStandard));
        MapFilters.Add(new MapFilter(Resources.Localization.Locals_German.urbanization));
    }
}