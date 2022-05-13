using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Data.Components;

public struct DataVertex
{
    public Vector3 position;

    public float tileType;
    public float terrainType;

    public float popByTribe;
    public float countries;
    public float lifeStandard;
    public float urbanization;

    public DataVertex(Vector3 position)
    {
        this.position = position;
        tileType = 0;
        terrainType = 0;
        popByTribe = 0;
        countries = 0;
        lifeStandard = 0;
        urbanization = 0;
    }
}