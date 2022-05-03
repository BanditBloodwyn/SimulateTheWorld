using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Data.OpenGL;

public struct DataVertex
{
    public Vector3 position;
    public int tileType;
    public int terrainType;

    public DataVertex(Vector3 position, int tileType, int terrainType)
    {
        this.position = position;
        this.tileType = tileType;
        this.terrainType = terrainType;
    }
}