using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Data.OpenGL;

public struct DataVertex
{
    public Vector3 position;
    public float tileType;
    public float terrainType;

    public DataVertex(Vector3 position, float tileType, float terrainType)
    {
        this.position = position;
        this.tileType = tileType;
        this.terrainType = terrainType;
    }
}