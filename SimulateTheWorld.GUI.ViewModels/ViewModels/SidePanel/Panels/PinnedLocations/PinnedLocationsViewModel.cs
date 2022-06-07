using System;
using System.Collections.ObjectModel;
using System.Linq;
using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.Core.GUI.MVVM.Mediator;
using SimulateTheWorld.GUI.ViewModels.Commands;
using SimulateTheWorld.GUI.ViewModels.Mediation.Mediators;
using SimulateTheWorld.GUI.ViewModels.Mediation.Messages;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel.Panels.PinnedLocations;

public class PinnedLocationsViewModel : ObservableObject, ISubscriber<IMessage>
{
    public ObservableCollection<Tuple<Location?, int>> Locations { get; }

    public MoveToPinnedLocationCommand MoveToPinnedLocationCommand { get; }

    public PinnedLocationsViewModel()
    {
        LocationMediator.Instance.Subscribe(this);

        Locations = new ObservableCollection<Tuple<Location?, int>>();

        MoveToPinnedLocationCommand = new MoveToPinnedLocationCommand();
    }


    public void Handle(IMessage message)
    {
        if (message is not LocationMessage locationMessage) 
            return;

        if (locationMessage.Location == null)
            return;

        if (Locations.Any(loc => loc.Item1?.Name == locationMessage.Location.Name))
            Locations.Remove(Locations.First(loc => loc.Item1?.Name == locationMessage.Location.Name));
        else
            Locations.Add( new Tuple<Location?, int>(locationMessage.Location, locationMessage.ID ));
    }
}