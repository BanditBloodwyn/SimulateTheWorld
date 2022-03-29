using SimulateTheWorld.Core.MVVM;

namespace SimulateTheWorld.Models.SidePanel.Panels.MapFilters;

public class MapFilter : ObservableObject
{
    private bool _active;

    public string Name { get; }

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

    public MapFilter(string name, bool active = false)
    {
        Name = name;
        Active = active;
    }
}