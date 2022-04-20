using System;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public static class TestData
{
    public static float[] Vertices => new float[]
    { 
        // COORDS                                          COLORS
        -0.5f,  -0.5f * MathF.Sqrt(3) / 3,     0.0f,     0.8f,  0.3f,  0.02f,
        0.5f,   -0.5f * MathF.Sqrt(3) / 3,     0.0f,     0.8f,  0.3f,  0.02f,
        0.0f,    0.5f * MathF.Sqrt(3) * 2 / 3, 0.0f,     1.0f,  0.9f,  0.32f,
        -0.25f,  0.5f * MathF.Sqrt(3) / 6,     0.0f,     0.9f,  0.45f, 0.17f,
        0.25f,   0.5f * MathF.Sqrt(3) / 6,     0.0f,     0.9f,  0.45f, 0.17f,
        0.0f,   -0.5f * MathF.Sqrt(3) / 3,     0.0f,     0.8f,  0.3f,  0.02f
    };

    public static int[] Indices => new int[]
    {
        0, 3, 5,
        3, 2, 4,
        5, 4, 1
    };
}