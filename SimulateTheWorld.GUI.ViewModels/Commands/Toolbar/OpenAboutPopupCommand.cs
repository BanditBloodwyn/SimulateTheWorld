using System.Windows.Controls;
using SimulateTheWorld.GUI.Dialogs.Popups.Toolbar;
using SimulateTheWorld.GUI.ViewModels.Commands.Base;

namespace SimulateTheWorld.GUI.ViewModels.Commands.Toolbar;

public class OpenAboutPopupCommand : OpenPopupCommand
{
    protected override UserControl OpenControl => new AboutControl();
}