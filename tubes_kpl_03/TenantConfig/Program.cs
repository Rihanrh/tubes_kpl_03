using System;
using System.Text.Json;

public class statusPesananConfig
{
    public List<string> listTenant { get; set; }

    public statusPesananConfig() { }

    public statusPesananConfig(List<string> listTenant)
    {
        this.listTenant = listTenant;
    }
}

public class typeConfig
{
    public statusPesananConfig config;
    public const string filePath = @"./type_acc.json";

    public typeConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch
        {
            setDefault();
            WriteNewConfigFile();
        }
    }


    public statusPesananConfig ReadConfigFile()
    {
        string configJSONData = File.ReadAllText(filePath);
        config = JsonSerializer.Deserialize<statusPesananConfig>(configJSONData);
        return config;
    }
    public void setDefault()
    {
        List<string> method = new List<string>() { "Rasya", "Katsu", "Kansas" };
        config = new statusPesananConfig(method);
    }

    public void WriteNewConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(config, options);
        File.WriteAllText(filePath, jsonString);
    }
}

