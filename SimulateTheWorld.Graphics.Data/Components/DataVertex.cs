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
    public float ressource_ironOre;
    public float ressource_goldOre;
    public float ressource_oil;
    public float ressource_gas;
    
    public float flora_deciduousTrees;
    public float flora_evergreenTrees;
    public float flora_vegetables;
    public float flora_fruits;

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
        ressource_ironOre = 0;
        ressource_goldOre = 0;
        ressource_oil = 0;
        ressource_gas = 0;

        flora_deciduousTrees = 0;
        flora_evergreenTrees = 0;
        flora_vegetables = 0;
        flora_fruits = 0;
    }
}