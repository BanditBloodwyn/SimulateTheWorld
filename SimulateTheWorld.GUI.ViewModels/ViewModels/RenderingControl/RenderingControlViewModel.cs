using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.GUI.ViewModels.Commands.RenderingControl;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.RenderingControl;

public class RenderingControlViewModel : ObservableObject
{
    public OpenTileContextMenuCommand OpenTileContextMenuCommand { get; }
    
    public RenderingControlViewModel()
    {
        OpenTileContextMenuCommand = new OpenTileContextMenuCommand();
    }
}