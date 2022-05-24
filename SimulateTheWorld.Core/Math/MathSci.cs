using System;

namespace SimulateTheWorld.Core.Math;

public static class MathSci
{
    public static float Bump(float value, float bumpHeight, float bumpWidth, float offset, float steepness)
    {
        return bumpHeight / (1 + MathF.Pow(MathF.Abs((value - offset) / bumpWidth), steepness));
    }
}