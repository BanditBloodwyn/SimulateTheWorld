using SimulateTheWorld.GUI.Commands.Toolbar;
using SimulateTheWorld.GUI.Core.MVVM;

namespace SimulateTheWorld.GUI.ViewModels.Toolbar;

public class STWToolbarViewModel : ObservableObject
{
    public OpenAboutPopupCommand OpenAboutPopupCommand { get; set; }

    public STWToolbarViewModel()
    {
        OpenAboutPopupCommand = new OpenAboutPopupCommand();
    }
}