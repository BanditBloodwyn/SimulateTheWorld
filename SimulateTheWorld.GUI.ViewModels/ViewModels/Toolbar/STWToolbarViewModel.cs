using System.Windows.Controls;
using SimulateTheWorld.Core.MVVM;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.Toolbar;

public class STWToolbarViewModel : ObservableObject
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