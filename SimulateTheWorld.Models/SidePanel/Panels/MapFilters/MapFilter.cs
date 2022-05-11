using System;
using SimulateTheWorld.Core.MVVM;

namespace SimulateTheWorld.Models.SidePanel.Panels.MapFilters;

public class MapFilter : ObservableObject
{
    private bool _active;

    public event Action? MapFilterChanged;

    public string? DisplayName { get; set; }
    
    public MapFilterType Type { get; }

    public bool Active
    {
        get => _active;
        set
        {
            if (_active != value)
            {
                _active = value;
                MapFilterChanged?.Invoke();
                OnPropertyChanged();
            }
        }
    }

    public MapFilter(MapFilterType type, bool active = false)
    {
        Type = type;
        Active = active;
    }
}