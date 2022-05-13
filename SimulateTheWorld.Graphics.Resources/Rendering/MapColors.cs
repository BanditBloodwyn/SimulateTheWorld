using System.Drawing;
using SimulateTheWorld.Core.Types.Enums;

namespace SimulateTheWorld.Graphics.Resources.Rendering;

public static class MapColors
{
    // ======================== CONSTANT COLORS ========================
    public static Color MarkedTileColor => Color.Red;


    // ======================== FILTER COLORS ========================
    // Color sets
    private static Color[] Filter_PopByTribe => new[] { Color.Red, Color.GreenYellow }; // TODO: needs to be changed
    private static Color[] Filter_Countries => new[] { Color.Red, Color.GreenYellow }; // TODO: needs to be changed

    // Color pairs
    private static Color[] Filter_LifeStandard => new[] { Color.Red, Color.GreenYellow };
    private static Color[] Filter_Urbanization => new[] { Color.LimeGreen, Color.SaddleBrown };

    public static Color[] GetColorsByFilterType(MapFilterType type)
    {
        return type switch
        {
            MapFilterType.PopByTribe => Filter_PopByTribe,
            MapFilterType.Countries => Filter_Countries,
            MapFilterType.LifeStandard => Filter_LifeStandard,
            MapFilterType.Urbanization => Filter_Urbanization,
            _ => new[] { Color.White, Color.White }
        };
    }
}