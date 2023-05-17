using Newtonsoft.Json;

namespace console_weather.API; 

public static class JsonHandler {
    private static readonly string Dirpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "weather_data");
    public static readonly string Configpath = Path.Combine(Dirpath, "config.json");
    
    public static void CreateConfigJsonFile() {
        if (!Directory.Exists(Dirpath)) {
            Directory.CreateDirectory(Dirpath);
        }
        
        var configFilePath = Configpath;
        
        var config = new { };
        var configJson = JsonConvert.SerializeObject(config, Formatting.Indented);

        File.WriteAllText(configFilePath, configJson);
    }
}