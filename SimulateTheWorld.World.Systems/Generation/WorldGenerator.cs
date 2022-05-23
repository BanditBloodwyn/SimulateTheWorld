using SimulateTheWorld.Core.Types;
using SimulateTheWorld.World.Data.Data.Types;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.World.Systems.Generation;

public class WorldGenerator
{
    private readonly HeightGenerator _heightGenerator;
    private readonly RessourceGenerator _ressourceGenerator;
    private readonly VegetationGenerator _vegetationGenerator;

    public CatalogCollection CatalogCollection { get; set; }

    public WorldGenerator()
    {
        _heightGenerator = new HeightGenerator();
        _ressourceGenerator = new RessourceGenerator();
        _vegetationGenerator = new VegetationGenerator();

        CatalogCollection = new CatalogCollection();
    }

    public void CreateCatalog()
    {
        CatalogCollection.TerrainHeights = new float[STWWorld.TerrainSize * STWWorld.TerrainSize];

        for (int x = 0; x < STWWorld.TerrainSize; x++)
        for (int z = 0; z < STWWorld.TerrainSize; z++)
            CatalogCollection.TerrainHeights[x * STWWorld.TerrainSize + z] = _heightGenerator.CalculateHeight(x, z);
    }

    public TerrainTile CreateTerrainTile(int x, int y)
    {
        int tileID = x * STWWorld.TerrainSize + y;

        TerrainTile tile = new();

        tile.ID = tileID;
        tile.Location = new Location($"Tile {tileID}", new Coordinate(y, x));

        if (CatalogCollection.TerrainHeights == null)
            return tile;

        tile.TerrainValues.Height = CatalogCollection.TerrainHeights[tileID];
        tile.TileType = TerrainSampler.GeTileTypeByHeight(CatalogCollection.TerrainHeights[tileID]);
        tile.VegetationType = TerrainSampler.GetVegetationTypeByHeight(CatalogCollection.TerrainHeights[tileID]);
        
        _ressourceGenerator.GenerateRessources(tile);
        _vegetationGenerator.GenerateVegetation(tile);

        return tile;
    }
}