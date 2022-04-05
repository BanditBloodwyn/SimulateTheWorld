using SimulateTheWorld.Core.MVVM;

namespace SimulateTheWorld.Models.SidePanel.Panels.MapFilters;

public class MapFilter : ObservableObject
{
    private bool _active;

    public string? DisplayName { get; set; }
    
    public bool Active
    {
        get => _active;
        set
        {
            if (_active != value)
            {
                _active = value;
                OnPropertyChanged();
            }
        }
    }

    public MapFilter(bool active = false)
    {
        Active = active;
    }
}