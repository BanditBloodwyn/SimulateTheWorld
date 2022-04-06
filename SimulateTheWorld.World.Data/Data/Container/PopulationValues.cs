using System.ComponentModel.DataAnnotations;
using SimulateTheWorld.World.Data.Data.Types;

namespace SimulateTheWorld.World.Data.Data.Container;

public class PopulationValues
{
    [Range(-100, 100)]
    public int LifeStandard { get; set; }

    [Range(0, 100)]
    public int Urbanization { get; set; }

    public Population Population { get; set; }

    public PopulationValues()
    {
        LifeStandard = -100;
        Urbanization = 0;
        Population = new Population();
    }
}