using SimulateTheWorld.Rendering.Rendering.Classes.Components;

namespace SimulateTheWorld.Rendering.Rendering.Classes.Shapes;

public class STWShape
{
    public float[]? Vertices { get; protected set; }
    public uint[]? Indices { get; protected set; }
    public float[]? Normals { get; protected set; }

    public Transform Transform { get; set; }
    public Material Material { get; set; }

    protected STWShape()
    { 
        Transform = new Transform();
        Material = new Material();
    }
}