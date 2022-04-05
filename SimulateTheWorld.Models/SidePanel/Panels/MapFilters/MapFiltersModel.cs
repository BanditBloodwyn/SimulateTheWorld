namespace SimulateTheWorld.Models.SidePanel.Panels.MapFilters;

public class MapFiltersModel
{
    public MapFilter PopByTribeFilter { get; }
    public MapFilter CountriesFilter { get; }
    public MapFilter LifeStandardFilter { get; }
    public MapFilter UrbanizationFilter { get; }

    public MapFiltersModel()
    {
        PopByTribeFilter = new MapFilter(true);
        CountriesFilter = new MapFilter();
        LifeStandardFilter = new MapFilter();
        UrbanizationFilter = new MapFilter();
    }
}