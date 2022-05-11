using System;
using System.Drawing;
using SimulateTheWorld.Models.SidePanel.Panels.MapFilters;

namespace SimulateTheWorld.Graphics.Resources.Rendering;

public class MapFilterColors
{
    // Color sets
    private static Color[] PopByTribe => new[] { Color.Red, Color.GreenYellow }; // TODO: needs to be changed
    private static Color[] Countries => new[] { Color.Red, Color.GreenYellow }; // TODO: needs to be changed

    // Color pairs
    private static Color[] LifeStandard => new[] { Color.Red, Color.GreenYellow };
    private static Color[] Urbanization => new[] { Color.LimeGreen, Color.SaddleBrown };

    public static Color[] GetColorsByFilterType(MapFilterType type)
    {
        return type switch
        {
            MapFilterType.PopByTribe => PopByTribe,
            MapFilterType.Countries => Countries,
            MapFilterType.LifeStandard => LifeStandard,
            MapFilterType.Urbanization => Urbanization,
            _ => new[] { Color.White, Color.White }
        };
    }
}