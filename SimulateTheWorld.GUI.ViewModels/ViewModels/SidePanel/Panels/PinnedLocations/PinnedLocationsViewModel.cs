using System.Collections.ObjectModel;
using System.Linq;
using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.Core.GUI.MVVM.Mediator;
using SimulateTheWorld.Models.Mediators;
using SimulateTheWorld.World.Data.Data.Types;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel.Panels.PinnedLocations;

public class PinnedLocationsViewModel : ObservableObject, ISubscriber<IMessage>
{
    private readonly IMediator _locationMediator;

    public ObservableCollection<Location> Locations { get; set; }

    public PinnedLocationsViewModel()
    {
        _locationMediator = LocationMediator.Instance;
        _locationMediator.Subscribe(this);

        Locations = new ObservableCollection<Location>();
    }


    public void Handle(IMessage message)
    {
        if (message is LocationMessage locationMessage)
        {
            if (locationMessage.Pin)
                Locations.Add(locationMessage.Location);
            else
                Locations.Remove(Locations.First(loc => loc.Name == locationMessage.Location.Name));
        }
    }
}