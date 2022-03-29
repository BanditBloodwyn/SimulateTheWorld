using SimulateTheWorld.ViewModels.Core;

namespace SimulateTheWorld.ViewModels.SidePanel.Panels.MapFilters;

public class MapFiltersViewModel : ObservableObject
{
    public MapFilter PopByTribeFilter { get; set; }
    public MapFilter CountriesFilter { get; set; }
    public MapFilter LifeStandardFilter { get; set; }
    public MapFilter UrbanizationFilter { get; set; }

    public MapFiltersViewModel()
    {
        PopByTribeFilter = new MapFilter(Resources.Localization.Locals_German.mapfilters_popByTribe, true);
        CountriesFilter = new MapFilter(Resources.Localization.Locals_German.mapfilters_countries);
        LifeStandardFilter = new MapFilter(Resources.Localization.Locals_German.mapfilters_lifeStandard);
        UrbanizationFilter = new MapFilter(Resources.Localization.Locals_German.urbanization);
    }
}