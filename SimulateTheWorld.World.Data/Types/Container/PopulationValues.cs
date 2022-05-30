using System.ComponentModel.DataAnnotations;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.World.Data.Types.Container;

public class PopulationValues
{
    [Range(0, 100)]
    public float LifeStandard { get; set; }

    [Range(0, 100)]
    public float Urbanization { get; set; }

    public Population Population { get; set; } = new();
}