﻿using System.Windows.Controls;
using SimulateTheWorld.GUI.Commands.Base;
using SimulateTheWorld.GUI.Dialogs.Popups.Toolbar;

namespace SimulateTheWorld.GUI.Commands.Toolbar;

public class OpenAboutPopupCommand : OpenPopupCommand
{
    protected override UserControl OpenControl => new AboutControl();
}