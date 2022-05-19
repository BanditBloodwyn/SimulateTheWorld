using System;
using System.Numerics;

namespace SimulateTheWorld.Core.Math.Noise.Filters;

public class StandardNoiseFilter : INoiseFilter
{
    private readonly PerlinNoise _perlinNoise;

    private readonly float _strength;
    private readonly float _roughness;
    private readonly float _baseRoughness;
    private readonly float _persistance;

    public int NumberOfLayers { get; set; }
    public float MinValue { get; set; }
    public Vector3 Center { get; set; }

    public StandardNoiseFilter(int numberOfLayers, float strength, float minValue, float roughness, float baseRoughness, float persistance, Vector3 center)
    {
        Random random = new Random();

        _perlinNoise = new PerlinNoise(random.Next(9999));
        _strength = strength;
        _roughness = roughness;
        _baseRoughness = baseRoughness;
        _persistance = persistance;
        NumberOfLayers = numberOfLayers;
        MinValue = minValue;
        Center = center;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = _baseRoughness;
        float amplitude = 1;

        for (int i = 0; i < NumberOfLayers; i++)
        {
            float v = _perlinNoise.Evaluate(point * frequency + Center);
            noiseValue += (v + 1) * 0.5f * amplitude;
            frequency *= _roughness;
            amplitude *= _persistance;
        }

        noiseValue = MathF.Max(0, noiseValue - MinValue);
        return noiseValue * _strength;
    }
}