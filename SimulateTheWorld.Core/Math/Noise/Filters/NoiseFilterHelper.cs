using System;
using System.Numerics;
using SimulateTheWorld.Core.Types;

namespace SimulateTheWorld.Core.Math.Noise.Filters;

public static class NoiseFilterHelper
{
    public static float Calculate(this INoiseFilter filter, Coordinate? coordinate, float frequency, Vector3 offset, int layers, float minValue, float strength)
    {
        if (coordinate == null)
            return 0;

        int x = coordinate.Value.X;
        int z = coordinate.Value.Y;

        filter.NumberOfLayers = layers;
        filter.Center = offset;
        filter.MinValue = minValue;
        filter.Strength = strength;
        float value = MathF.Min(filter.Evaluate(new Vector3(x, 0, z)), 100);

        return value * frequency / 100;
    }
}