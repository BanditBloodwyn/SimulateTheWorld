﻿using System;
using System.ComponentModel.DataAnnotations;
using SimulateTheWorld.World.Data.Data.Types;

namespace SimulateTheWorld.World.Data.Data.Container;

public class PopulationValues
{
    [Range(0, 100)]
    public float LifeStandard { get; set; }

    [Range(0, 100)]
    public float Urbanization { get; set; }

    public Population Population { get; set; }

    public PopulationValues()
    {
        Random random = new Random();

        LifeStandard = (float)random.NextDouble() * 100;
        Urbanization = 0;
        Population = new Population();
    }
}