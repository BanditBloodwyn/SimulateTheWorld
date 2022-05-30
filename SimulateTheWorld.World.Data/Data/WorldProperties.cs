using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using SimulateTheWorld.World.Resources;

namespace SimulateTheWorld.World.Data.Data;

public class WorldProperties
{
    private static WorldProperties? _instance;

    public int WorldSize { get; set; }
    public float TileTotalSize { get; set; }
    public float TileFillSize { get; set; }
    public float VegetationSpreadingSpeed { get; set; }

    public static WorldProperties Instance => _instance ??= new WorldProperties();

    private WorldProperties()
    {
        WorldPropertiesContainer container = ReadJson();

        WorldSize = container.WorldSize; 
        TileTotalSize = container.TileTotalSize;
        TileFillSize = container.TileFillSize;

        VegetationSpreadingSpeed = container.VegetationSpreadingSpeed;
    }

    private WorldPropertiesContainer ReadJson()
    {
        try
        {
            string jsonFromFile;
            using (var reader = new StreamReader(Jsons.WorldData))
                jsonFromFile = reader.ReadToEnd();

            WorldPropertiesContainer? container = JsonConvert.DeserializeObject<WorldPropertiesContainer>(jsonFromFile);
            return container ?? new WorldPropertiesContainer();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
    }
}