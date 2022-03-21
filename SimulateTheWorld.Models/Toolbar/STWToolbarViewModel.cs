using System.Windows.Controls;
using SimulateTheWorld.Models.Core;

namespace SimulateTheWorld.Models.Toolbar;

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