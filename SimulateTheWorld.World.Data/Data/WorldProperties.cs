using System;
using System.IO;
using Newtonsoft.Json;
using SimulateTheWorld.Core.Logging;
using SimulateTheWorld.World.Resources;

namespace SimulateTheWorld.World.Data.Data;

public class WorldProperties
{
    private static WorldProperties? _instance;

    public int WorldSize { get; }
    public float TileTotalSize { get; }
    public float TileFillSize { get; }
    public float VegetationSpreadingSpeed { get; }

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