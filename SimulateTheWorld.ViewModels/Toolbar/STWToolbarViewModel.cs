using System.Windows.Controls;
using SimulateTheWorld.Core.MVVM;
using DelegateCommand = SimulateTheWorld.ViewModels.Core.DelegateCommand;

namespace SimulateTheWorld.ViewModels.Toolbar;

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