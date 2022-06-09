using SimulateTheWorld.GUI.Core.MVVM;
using SimulateTheWorld.GUI.Core.MVVM.Commands;
using SimulateTheWorld.GUI.Dialogs.Popups.Toolbar;

namespace SimulateTheWorld.GUI.ViewModels.Toolbar;

public class STWToolbarViewModel : ObservableObject
{
    public OpenPopupCommand OpenAboutPopupCommand { get; set; }

    public STWToolbarViewModel()
    {
        OpenAboutPopupCommand = new OpenPopupCommand { OpenControl = new AboutControl() };
    }
}