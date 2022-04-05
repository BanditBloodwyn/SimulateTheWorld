using SimulateTheWorld.GUI.Resources.Localization;

namespace SimulateTheWorld.Models.SidePanel.Panels.MapFilters;

public class MapFiltersModel
{
    public MapFilter PopByTribeFilter { get; set; }
    public MapFilter CountriesFilter { get; set; }
    public MapFilter LifeStandardFilter { get; set; }
    public MapFilter UrbanizationFilter { get; set; }

    public MapFiltersModel()
    {
        PopByTribeFilter = new MapFilter(Locals_German.mapfilters_popByTribe, true);
        CountriesFilter = new MapFilter(Locals_German.mapfilters_countries);
        LifeStandardFilter = new MapFilter(Locals_German.mapfilters_lifeStandard);
        UrbanizationFilter = new MapFilter(Locals_German.mapfilters_urbanization);
    }
}