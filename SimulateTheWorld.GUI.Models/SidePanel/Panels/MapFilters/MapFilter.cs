using System;
using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.Core.Types.Enums;

namespace SimulateTheWorld.GUI.Models.SidePanel.Panels.MapFilters;

public class MapFilter : ObservableObject
{
    private bool _active;

    public event Action? MapFilterChanged;
    public event Action<MapFilter>? OnMapFilterChanged;

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
                if(_active)
                    OnMapFilterChanged?.Invoke(this);
            }
        }
    }

    public MapFilter(MapFilterType type, bool active = false)
    {
        Type = type;
        Active = active;
    }
}