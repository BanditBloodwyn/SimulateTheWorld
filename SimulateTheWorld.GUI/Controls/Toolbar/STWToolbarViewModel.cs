using System.Windows.Controls;
using SimulateTheWorld.GUI.Core;

namespace SimulateTheWorld.GUI.Controls.Toolbar;

public class STWToolbarViewModel : BaseViewModel
{
    public DelegateCommand OpenMenuCommand { get; }

    public STWToolbarViewModel()
    {
        OpenMenuCommand = new DelegateCommand(
            (o) =>
            {
                if (o is ContextMenu contextMenu)
                {
                    contextMenu.IsOpen = true;
                }
            });
    }
}