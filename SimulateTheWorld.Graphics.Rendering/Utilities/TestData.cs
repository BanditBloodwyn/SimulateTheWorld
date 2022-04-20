using System;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public static class TestData
{
    public static float[] Vertices => new float[]
    { 
        // COORDS                  COLORS
        -0.5f,  -0.5f,   0.0f,     1.0f,  0.0f,  0.0f,
        -0.5f,   0.5f,   0.0f,     0.0f,  1.0f,  0.0f,
         0.5f,   0.5f,   0.0f,     0.0f,  0.0f,  1.0f,
         0.5f,  -0.5f,   0.0f,     1.0f,  1.0f,  1.0f,
    };

    public static int[] Indices => new int[]
    {
        0, 2, 1,
        0, 3, 2,
    };
}