using System;
using System.Numerics;

namespace SimulateTheWorld.Core.Math.Noise.Filters;

public class StandardNoiseFilter
{
    private readonly PerlinNoise _perlinNoise;

    private readonly int _numberOfLayers;
    private readonly float _strength;
    private readonly float _minValue;
    private readonly float _roughness;
    private readonly float _baseRoughness;
    private readonly float _persistance;
    private readonly Vector3 _center;

    public StandardNoiseFilter(int numberOfLayers, float strength, float minValue, float roughness, float baseRoughness, float persistance, Vector3 center)
    {
        _perlinNoise = new PerlinNoise();
        _numberOfLayers = numberOfLayers;
        _strength = strength;
        _minValue = minValue;
        _roughness = roughness;
        _baseRoughness = baseRoughness;
        _persistance = persistance;
        _center = center;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = _baseRoughness;
        float amplitude = 1;

        for (int i = 0; i < _numberOfLayers; i++)
        {
            float v = _perlinNoise.Evaluate(point * frequency + _center);
            noiseValue += (v + 1) * 0.5f * amplitude;
            frequency *= _roughness;
            amplitude *= _persistance;
        }

        noiseValue = MathF.Max(0, noiseValue - _minValue);
        return noiseValue * _strength;
    }
}