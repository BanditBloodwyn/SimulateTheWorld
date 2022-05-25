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

    public Vector3 ressource_fossils;
    public Vector4 ressource_standardOres;
    public Vector3 ressource_preciousOres;

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
        
        ressource_fossils = Vector3.Zero;
        ressource_standardOres = Vector4.Zero;
        ressource_preciousOres = Vector3.Zero;

        floraValues = Vector4.Zero;
    }
}