using System;
using SimulateTheWorld.Core.MVVM;

namespace SimulateTheWorld.GUI.ViewModels.SidePanel;

public class SidePanelViewModel : ObservableObject
{
    public DelegateCommand NextRoundCommand { get; }

    public event Action NextRound;

    public SidePanelViewModel()
    {
        NextRoundCommand = new DelegateCommand(
            (o) =>
            {
                NextRound?.Invoke();
            });
    }
}