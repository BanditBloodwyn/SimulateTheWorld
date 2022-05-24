using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Data.Components;

public struct DataVertex
{
    public Vector3 position;

    public float marked;

    public float tileType;
    public float vegetationType;

    public float height;

    public float lifeStandard;
    public float urbanization;

    public float ressource_coal;
    public float ressource_ironOre;
    public float ressource_goldOre;
    public float ressource_oil;
    public float ressource_gas;

    public Vector4 floraValues;

    public DataVertex(Vector3 position)
    {
        this.position = position;

        marked = 0.0f;

        tileType = 0;
        vegetationType = 0;

        height = 0;
        lifeStandard = 0;
        urbanization = 0;

        ressource_coal = 0;
        ressource_ironOre = 0;
        ressource_goldOre = 0;
        ressource_oil = 0;
        ressource_gas = 0;

        floraValues = Vector4.Zero;
    }
}