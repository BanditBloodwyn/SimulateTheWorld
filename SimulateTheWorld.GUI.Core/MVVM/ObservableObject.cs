using System.ComponentModel;
using System.Runtime.CompilerServices;
using SimulateTheWorld.Core.Logging;

namespace SimulateTheWorld.GUI.Core.MVVM;

public class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        Logger.Debug(this, $"OnPropertyChanged: {propertyName}");

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}