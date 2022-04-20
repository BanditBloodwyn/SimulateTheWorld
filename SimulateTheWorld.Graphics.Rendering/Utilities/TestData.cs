using System;
using System.Collections.Generic;
using SimulateTheWorld.Graphics.Shapes;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public static class TestData
{
    public static float[] Vertices => new float[]
    {
        -0.5f, -0.5f * MathF.Sqrt(3) / 3, 0.0f,
        0.5f, -0.5f * MathF.Sqrt(3) / 3, 0.0f,
        0.0f, 0.5f * MathF.Sqrt(3) * 2 / 3, 0.0f,
    };
}