using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Data.OpenGL;

public struct DataVertex
{
    public Vector3 position;

    public float tileType;
    public float terrainType;

    public float popByTribe;
    public float countries;
    public float lifeStandard;
    public float urbanization;

    public DataVertex(Vector3 position, float tileType, float terrainType, float popByTribe, float countries, float lifeStandard, float urbanization)
    {
        this.position = position;

        this.tileType = tileType;
        this.terrainType = terrainType;

        this.popByTribe = popByTribe;
        this.countries = countries;
        this.lifeStandard = lifeStandard;
        this.urbanization = urbanization;
    }
}