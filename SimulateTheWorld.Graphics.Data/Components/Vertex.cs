using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Data.Components;

public struct Vertex
{
    public Vector3 position;
    public Vector3 normal;
    public Vector3 color;
    public Vector2 textureUV;

    public Vertex(Vector3 pos, Vector3 norm, Vector3 col, Vector2 texUV)
    {
        position = pos;
        normal = norm;
        color = col;
        textureUV = texUV;
    }
}