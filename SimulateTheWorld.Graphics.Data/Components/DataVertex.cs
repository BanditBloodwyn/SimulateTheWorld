using OpenTK.Mathematics;

namespace SimulateTheWorld.Graphics.Data.Components;

public struct DataVertex
{
    public Vector3 position;

    public float marked;

    public float tileType;
    public float vegetationType;

    public float height;
    public float popByTribe;
    public float countries;
    public float lifeStandard;
    public float urbanization;
    public float ressource_coal;

    public DataVertex(Vector3 position)
    {
        this.position = position;

        marked = 0.0f;

        tileType = 0;
        vegetationType = 0;

        height = 0;
        popByTribe = 0;
        countries = 0;
        lifeStandard = 0;
        urbanization = 0;

        ressource_coal = 0;
    }
}