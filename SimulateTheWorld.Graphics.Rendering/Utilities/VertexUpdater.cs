using System;
using System.Diagnostics;
using System.Windows.Threading;
using SimulateTheWorld.Graphics.Data.Components;
using SimulateTheWorld.Graphics.Data.Interfaces;
using SimulateTheWorld.World.Systems.Instances;

namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public static class VertexUpdater
{
    public static void UpdateVertexData(IDrawable drawable, Dispatcher? dispatcher = null)
    {
        int updatedVerticesCount = 0;

        try
        {
            if (drawable is PointCloud pointCloud)
            {
                for (int i = 0; i < pointCloud.Vertices.Length; i++)
                {
                    TerrainTile tile = STWWorld.Instance.Terrain.Tiles[i];

                    pointCloud.Vertices[i].marked = tile.Marked ? 1.0f : 0.0f;

                    pointCloud.Vertices[i].tileType = (int)tile.TileType;
                    pointCloud.Vertices[i].vegetationType = (int)tile.VegetationType;

                    pointCloud.Vertices[i].height = tile.TerrainValues.Height;
                    pointCloud.Vertices[i].popByTribe = tile.PopulationValues.Population.Quantity;
                    pointCloud.Vertices[i].countries = tile.PopulationValues.Population.Quantity;
                    pointCloud.Vertices[i].lifeStandard = tile.PopulationValues.LifeStandard;
                    pointCloud.Vertices[i].urbanization = tile.PopulationValues.Urbanization;
                    
                    pointCloud.Vertices[i].ressource_coal = tile.TerrainValues.Coal;
                    pointCloud.Vertices[i].ressource_ironOre = tile.TerrainValues.IronOre;
                    pointCloud.Vertices[i].ressource_goldOre = tile.TerrainValues.GoldOre;
                    pointCloud.Vertices[i].ressource_oil = tile.TerrainValues.Oil;
                    pointCloud.Vertices[i].ressource_gas = tile.TerrainValues.Gas;
                    
                    pointCloud.Vertices[i].floraValues.X = tile.FloraValues.DeciduousTrees;
                    pointCloud.Vertices[i].floraValues.Y = tile.FloraValues.EvergreenTrees;
                    pointCloud.Vertices[i].floraValues.Z = tile.FloraValues.Vegetables;
                    pointCloud.Vertices[i].floraValues.W = tile.FloraValues.Fruits;

                    updatedVerticesCount++;
                }

                if (dispatcher != null)
                    dispatcher.Invoke(pointCloud.UpdateVertexData);
                else
                    pointCloud.UpdateVertexData();
                Debug.WriteLine($"\tUpdated vertices: {updatedVerticesCount}");
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Vertex randomization failed: {e}");
            throw;
        }
    }
}