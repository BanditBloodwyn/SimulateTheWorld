using NotImplementedException = System.NotImplementedException;

namespace SimulateTheWorld.World.System.Generation;

public class WorldGenerator
{
    public CatalogCollection CatalogCollection { get; set; }

    public WorldGenerator()
    {
        CatalogCollection = new CatalogCollection();
    }


    public void CreateCatalog()
    {
        CatalogCollection.CreateCatalog();
    }
}