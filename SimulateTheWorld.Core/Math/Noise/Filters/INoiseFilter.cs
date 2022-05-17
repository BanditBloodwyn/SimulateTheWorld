using System.Numerics;

namespace SimulateTheWorld.Core.Math.Noise.Filters;

public interface INoiseFilter
{
    public float Evaluate(Vector3 point);
}