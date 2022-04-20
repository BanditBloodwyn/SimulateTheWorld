using System;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public static class TestData
{
    public static float[] Vertices => new float[]
    {
        -0.5f, -0.5f * MathF.Sqrt(3) / 3, 0.0f,
        0.5f, -0.5f * MathF.Sqrt(3) / 3, 0.0f,
        0.0f, 0.5f * MathF.Sqrt(3) * 2 / 3, 0.0f,
        -0.5f / 2, 0.5f * MathF.Sqrt(3) / 6, 0.0f,
        0.5f / 2, 0.5f * MathF.Sqrt(3) / 6, 0.0f,
        0.0f, -0.5f * MathF.Sqrt(3) / 3, 0.0f,
    };

    public static int[] Indices => new int[]
    {
        0, 3, 5,
        3, 2, 4,
        5, 4, 1
    };
}