using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimulateTheWorld.GUI.Core;

public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        if(!string.IsNullOrEmpty(propertyName))
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}