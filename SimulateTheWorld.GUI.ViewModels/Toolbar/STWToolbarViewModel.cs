using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.GUI.Commands.Toolbar;

namespace SimulateTheWorld.GUI.ViewModels.Toolbar;

public class STWToolbarViewModel : ObservableObject
{
    public OpenAboutPopupCommand OpenAboutPopupCommand { get; set; }

    public STWToolbarViewModel()
    {
        OpenAboutPopupCommand = new OpenAboutPopupCommand();
    }
}