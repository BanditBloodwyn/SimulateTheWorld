using System.Numerics;

namespace SimulateTheWorld.Core.Math.Noise.Filters;

public interface INoiseFilter
{
    public int NumberOfLayers { get; set; }
    public float Strength { get; set; }
    public float MinValue { get; set; }
    public Vector3 Center { get; set; }
 
    public float Evaluate(Vector3 point);
}