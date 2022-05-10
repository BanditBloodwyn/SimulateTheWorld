﻿using System;
using SimulateTheWorld.Core.MVVM;
using SimulateTheWorld.GUI.ViewModels.Commands;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel;

public class SidePanelViewModel : ObservableObject
{
    public NextRoundCommand NextRoundCommand { get; }

    public SidePanelViewModel()
    {
        NextRoundCommand = new NextRoundCommand();
    }

    public void SetNextRoundCommand(Action? triggerNextRound)
    {
        NextRoundCommand.TriggerNextRound += triggerNextRound;
    }
}