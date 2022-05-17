using System;
using System.Numerics;

namespace SimulateTheWorld.Core.Math.Noise.Filters;

public class RigidNoiseFilter : INoiseFilter
{
    private readonly PerlinNoise _perlinNoise;

    private readonly int _numberOfLayers;
    private readonly float _strength;
    private readonly float _minValue;
    private readonly float _roughness;
    private readonly float _baseRoughness;
    private readonly float _persistance;
    private readonly float _weightMultiplier;
    private readonly Vector3 _center;

    public RigidNoiseFilter(int numberOfLayers, float strength, float minValue, float roughness, float baseRoughness, float persistance, float weightMultiplier, Vector3 center)
    {
        _perlinNoise = new PerlinNoise();
        _numberOfLayers = numberOfLayers;
        _strength = strength;
        _minValue = minValue;
        _roughness = roughness;
        _baseRoughness = baseRoughness;
        _persistance = persistance;
        _weightMultiplier = weightMultiplier;
        _center = center;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = _baseRoughness;
        float amplitude = 1;
        float weight = 1;

        for (int i = 0; i < _numberOfLayers; i++)
        {
            float v = 1 - MathF.Abs(_perlinNoise.Evaluate(point * frequency + _center));

            v *= v;
            v *= weight;
            weight = System.Math.Clamp(v * _weightMultiplier, 0, 1);

            noiseValue += v * amplitude;
            frequency *= _roughness;
            amplitude *= _persistance;
        }

        noiseValue = MathF.Max(0, noiseValue - _minValue);
        return noiseValue * _strength;
    }
}