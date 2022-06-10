using System;
using System.IO;
using Newtonsoft.Json;
using SimulateTheWorld.Core.Logging;
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
        WorldPropertiesJsonContainer jsonContainer = ReadJson();

        WorldSize = jsonContainer.WorldSize; 
        TileTotalSize = jsonContainer.TileTotalSize;
        TileFillSize = jsonContainer.TileFillSize;

        VegetationSpreadingSpeed = jsonContainer.VegetationSpreadingSpeed;
    }

    private WorldPropertiesJsonContainer ReadJson()
    {
        try
        {
            string jsonFromFile;
            using (var reader = new StreamReader(Jsons.WorldData))
                jsonFromFile = reader.ReadToEnd();

            WorldPropertiesJsonContainer? container = JsonConvert.DeserializeObject<WorldPropertiesJsonContainer>(jsonFromFile);
            return container ?? new WorldPropertiesJsonContainer();
        }
        catch (Exception e)
        {
            Logger.Info(this, "ReadJson failed", e.ToString());
            throw;
        }
    }
}