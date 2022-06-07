using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.GUI.ViewModels.Commands.Toolbar;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.Toolbar;

public class STWToolbarViewModel : ObservableObject
{
    public OpenAboutPopupCommand OpenAboutPopupCommand { get; set; }

    public STWToolbarViewModel()
    {
        OpenAboutPopupCommand = new OpenAboutPopupCommand();
    }
}