using System;
using System.Numerics;

namespace SimulateTheWorld.Core.Math.Noise.Filters;

public class RigidNoiseFilter : INoiseFilter
{
    private readonly PerlinNoise _perlinNoise;

    private readonly float _roughness;
    private readonly float _baseRoughness;
    private readonly float _persistance;
    private readonly float _weightMultiplier;
    
    public int NumberOfLayers { get; set; }
    public float Strength { get; set; }
    public float MinValue { get; set; }
    public Vector3 Center { get; set; }

    public RigidNoiseFilter(int numberOfLayers, float strength, float minValue, float roughness, float baseRoughness, float persistance, float weightMultiplier, Vector3 center)
    {
        _perlinNoise = new PerlinNoise();
        NumberOfLayers = numberOfLayers;
        Strength = strength;
        MinValue = minValue;
        _roughness = roughness;
        _baseRoughness = baseRoughness;
        _persistance = persistance;
        _weightMultiplier = weightMultiplier;
        Center = center;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = _baseRoughness;
        float amplitude = 1;
        float weight = 1;

        for (int i = 0; i < NumberOfLayers; i++)
        {
            float v = 1 - MathF.Abs(_perlinNoise.Evaluate(point * frequency + Center));

            v *= v;
            v *= weight;
            weight = System.Math.Clamp(v * _weightMultiplier, 0, 1);

            noiseValue += v * amplitude;
            frequency *= _roughness;
            amplitude *= _persistance;
        }

        noiseValue = MathF.Max(0, noiseValue - MinValue);
        return noiseValue * Strength;
    }
}