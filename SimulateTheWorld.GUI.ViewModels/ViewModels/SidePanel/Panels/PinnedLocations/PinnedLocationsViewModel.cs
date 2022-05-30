using System.Collections.ObjectModel;
using System.Linq;
using SimulateTheWorld.Core.GUI.MVVM;
using SimulateTheWorld.Core.GUI.MVVM.Mediator;
using SimulateTheWorld.GUI.Models.Mediators;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.GUI.ViewModels.ViewModels.SidePanel.Panels.PinnedLocations;

public class PinnedLocationsViewModel : ObservableObject, ISubscriber<IMessage>
{
    public ObservableCollection<Location?> Locations { get; }

    public PinnedLocationsViewModel()
    {
        LocationMediator.Instance.Subscribe(this);

        Locations = new ObservableCollection<Location?>();
    }


    public void Handle(IMessage message)
    {
        if (message is LocationMessage locationMessage)
        {
            if (locationMessage.Location == null)
                return;

            if (Locations.Any(loc => loc != null && loc.Name == locationMessage.Location.Name))
                Locations.Remove(Locations.First(loc => loc != null && loc.Name == locationMessage.Location.Name));
            else
                Locations.Add(locationMessage.Location);
        }
    }
}