using System;
using System.Windows.Controls;
using System.Windows.Input;
using SimulateTheWorld.Core.Types;
using SimulateTheWorld.GUI.ViewModels.SidePanel.Panels.PinnedLocations;

namespace SimulateTheWorld.GUI.Controls.Controls.MainPanels.SidePanel.Panels;

/// <summary>
/// Interaktionslogik für PinnedLocationsControl.xaml
/// </summary>
public partial class PinnedLocationsControl
{
    public PinnedLocationsControl()
    {
        InitializeComponent();
    }

    private void OnPinnedLocationClicked(object sender, MouseButtonEventArgs e)
    {
        if((sender as TreeViewItem)?.DataContext is Tuple<string?, Location?, int> location) 
            (DataContext as PinnedLocationsViewModel)?.MoveToPinnedLocationCommand.Execute(location);
    }
}