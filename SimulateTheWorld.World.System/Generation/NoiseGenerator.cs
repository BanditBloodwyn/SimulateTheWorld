using System.Numerics;
using SimulateTheWorld.Core.Math.Noise.Filters;

namespace SimulateTheWorld.World.System.Generation;

public class NoiseGenerator
{
    private readonly INoiseFilter[] _noiseFilters;

    private readonly StandardNoiseFilter _standardNoiseFilter;
    private readonly StandardNoiseFilter _terrainNoiseFilter;
    private readonly RigidNoiseFilter _mountainsNoiseFilter;

    public NoiseGenerator()
    {
        _standardNoiseFilter = new StandardNoiseFilter(10, 80, 0.4f, 10f, 0.002f, 0.1f, Vector3.Zero);
        _terrainNoiseFilter = new StandardNoiseFilter(10, 0.1f, 0.0f, 50f, 1.0f, 0.5f, Vector3.Zero);
        _mountainsNoiseFilter = new RigidNoiseFilter(10, 1.8f, 0.65f, 10f, 0.004f, 0.1f, 1f, Vector3.Zero);

        _noiseFilters = new INoiseFilter[]
        {
            _standardNoiseFilter,
            _terrainNoiseFilter,
            _mountainsNoiseFilter
        };
    }

    public float CalculateHeight(int x, int z)
    {
        float firstLayerValue = 0;
        float elevation = 0;
        Vector3 point = new Vector3(x, 0, z);

        if (_noiseFilters.Length > 0)
        {
            firstLayerValue = _noiseFilters[0].Evaluate(point);
            elevation = firstLayerValue;
        }

        if(_noiseFilters.Length == 1)
            return elevation;

        for (int i = 1; i < _noiseFilters.Length; i++)
        {
            float mask = firstLayerValue;
            elevation += _noiseFilters[i].Evaluate(point) * mask;
        }

        return elevation;
    }
}