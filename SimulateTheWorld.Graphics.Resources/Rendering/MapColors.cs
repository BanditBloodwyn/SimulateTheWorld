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
    private static Color[] Filter_Height => new[] { Color.Green, Color.Red };
    private static Color[] Filter_LifeStandard => new[] { Color.Red, Color.GreenYellow };
    private static Color[] Filter_Urbanization => new[] { Color.LimeGreen, Color.SaddleBrown };

    private static Color[] Filter_Flora_DeciduousTrees => new[] { Color.White, Color.ForestGreen };
    private static Color[] Filter_Flora_EvergreenTrees => new[] { Color.White, Color.DarkGreen };
    private static Color[] Filter_Flora_Vegetables => new[] { Color.White, Color.Green };
    private static Color[] Filter_Flora_Fruits => new[] { Color.White, Color.Red };
 
    private static Color[] Filter_Ressource_Coal => new[] { Color.White, Color.Black };
    private static Color[] Filter_Ressource_IronOre => new[] { Color.White, Color.OrangeRed };
    private static Color[] Filter_Ressource_GoldOre => new[] { Color.White, Color.Gold };
    private static Color[] Filter_Ressource_Oil => new[] { Color.White, Color.DarkSlateGray };
    private static Color[] Filter_Ressource_Gas => new[] { Color.White, Color.SaddleBrown };

    public static Color[] GetColorsByFilterType(MapFilterType type)
    {
        return type switch
        {
            MapFilterType.Height => Filter_Height,
            MapFilterType.PopByTribe => Filter_PopByTribe,
            MapFilterType.Countries => Filter_Countries,
            MapFilterType.LifeStandard => Filter_LifeStandard,
            MapFilterType.Urbanization => Filter_Urbanization,

            MapFilterType.Flora_DeciduousTrees => Filter_Flora_DeciduousTrees,
            MapFilterType.Flora_EvergreenTrees => Filter_Flora_EvergreenTrees,
            MapFilterType.Flora_Vegetables => Filter_Flora_Vegetables,
            MapFilterType.Flora_Fruits => Filter_Flora_Fruits,

            MapFilterType.Ressource_Coal => Filter_Ressource_Coal,
            MapFilterType.Ressource_IronOre => Filter_Ressource_IronOre,
            MapFilterType.Ressource_GoldOre => Filter_Ressource_GoldOre,
            MapFilterType.Ressource_Oil => Filter_Ressource_Oil,
            MapFilterType.Ressource_Gas => Filter_Ressource_Gas,
            _ => new[] { Color.White, Color.White }
        };
    }
}