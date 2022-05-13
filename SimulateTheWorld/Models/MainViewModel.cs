using SimulateTheWorld.Core.GUI.MVVM;

namespace SimulateTheWorld.Start.Models;

public class MainViewModel : ObservableObject
{
    public MainModel Model { get; }

    public MainViewModel()
    {
        Model = new MainModel();
    }
}