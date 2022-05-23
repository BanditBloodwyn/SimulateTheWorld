using System.Numerics;
using SimulateTheWorld.Core.Math.Noise.Filters;

namespace SimulateTheWorld.World.Systems.Generation;

public class HeightGenerator
{
    private readonly INoiseFilter[] _terrainNoiseFilters;

    private readonly StandardNoiseFilter _standardNoiseFilter;
    private readonly StandardNoiseFilter _terrainNoiseFilter;
    private readonly RigidNoiseFilter _mountainsNoiseFilter;

    public HeightGenerator()
    {
        _standardNoiseFilter = new StandardNoiseFilter(10, 80, 0.4f, 10f, 0.002f, 0.1f, Vector3.Zero);
        _terrainNoiseFilter = new StandardNoiseFilter(10, 0.1f, 0.0f, 50f, 1.0f, 0.5f, Vector3.Zero);
        _mountainsNoiseFilter = new RigidNoiseFilter(10, 2.5f, 0.65f, 10f, 0.004f, 0.1f, 1f, Vector3.Zero);

        _terrainNoiseFilters = new INoiseFilter[]
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

        if (_terrainNoiseFilters.Length > 0)
        {
            firstLayerValue = _terrainNoiseFilters[0].Evaluate(point);
            elevation = firstLayerValue;
        }

        if(_terrainNoiseFilters.Length == 1)
            return elevation;

        for (int i = 1; i < _terrainNoiseFilters.Length; i++)
        {
            float mask = firstLayerValue;
            elevation += _terrainNoiseFilters[i].Evaluate(point) * mask;
        }

        return elevation;
    }
}