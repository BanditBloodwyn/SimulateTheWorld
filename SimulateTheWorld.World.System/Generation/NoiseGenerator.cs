using System.Numerics;
using SimulateTheWorld.Core.Math.Noise.Filters;

namespace SimulateTheWorld.World.System.Generation;

public class NoiseGenerator
{
    private readonly INoiseFilter[] _noiseFilters;

    private readonly StandardNoiseFilter _standardNoiseFilter;
    private readonly RigidNoiseFilter _mountainsNoiseFilter;

    public NoiseGenerator()
    {
        _standardNoiseFilter = new StandardNoiseFilter(10, 80, 0.4f, 10f, 0.003f, 0.1f, Vector3.Zero);
        _mountainsNoiseFilter = new RigidNoiseFilter(10, 2, 0.6f, 50f, 0.005f, 0.1f, 1f, Vector3.Zero);

        _noiseFilters = new INoiseFilter[]
        {
            _standardNoiseFilter,
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