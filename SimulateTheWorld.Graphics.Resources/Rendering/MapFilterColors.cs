using System;
using System.Drawing;
using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Resources.Rendering;

public class MapFilterColors
{
    // Color sets
    public static Color[] PopByTribe => null;
    public static Color[] Countries => null;

    // Color pairs
    public static Color[] LifeStandard => new[] { Color.DarkGreen, Color.GreenYellow };
    public static Color[] Urbanization => new[] { Color.DarkGreen, Color.GreenYellow };

    public static Vector4 SampleColorPair(Color[] colors, float value)
    {
        if(value > 100 || value < 0)
            throw new ArgumentOutOfRangeException();

        value /= 100;

        float bk = (1 - value);
        float r = colors[0].R * bk + colors[1].R * value;
        float g = colors[0].G * bk + colors[1].G * value;
        float b = colors[0].B * bk + colors[1].B * value;

        r /= 255;
        g /= 255;
        b /= 255;

        return new Vector4(r, g, b, 1);
    }
}