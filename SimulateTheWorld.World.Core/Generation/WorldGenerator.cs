using SimulateTheWorld.Core.Types;
using SimulateTheWorld.World.Data.Data;
using SimulateTheWorld.World.Data.Types.Classes;

namespace SimulateTheWorld.World.Core.Generation;

public class WorldGenerator
{
    private readonly HeightGenerator _heightGenerator;
    private readonly RessourceGenerator _ressourceGenerator;
    private readonly VegetationGenerator _vegetationGenerator;

    private CatalogCollection CatalogCollection { get; }

    public WorldGenerator()
    {
        _heightGenerator = new HeightGenerator();
        _ressourceGenerator = new RessourceGenerator();
        _vegetationGenerator = new VegetationGenerator();

        CatalogCollection = new CatalogCollection();
    }

    public void CreateCatalog()
    {
        CatalogCollection.TerrainHeights = new float[WorldProperties.Instance.WorldSize * WorldProperties.Instance.WorldSize];

        for (int x = 0; x < WorldProperties.Instance.WorldSize; x++)
        for (int z = 0; z < WorldProperties.Instance.WorldSize; z++)
            CatalogCollection.TerrainHeights[x * WorldProperties.Instance.WorldSize + z] = _heightGenerator.CalculateHeight(x, z);
    }

    public TerrainTile CreateTerrainTile(int x, int y)
    {
        int tileID = x * WorldProperties.Instance.WorldSize + y;

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