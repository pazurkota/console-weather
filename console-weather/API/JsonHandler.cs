using Newtonsoft.Json;

namespace console_weather.API; 

public class JsonHandler {
    private static string DIRPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "weather_data");
    public static string CONFIGPATH = Path.Combine(DIRPATH, "config.json");
    
    public static void CreateConfigJsonFile() {
        if (!Directory.Exists(DIRPATH)) {
            Directory.CreateDirectory(DIRPATH);
        }
        
        var configFilePath = CONFIGPATH;
        
        var config = new { };
        var configJson = JsonConvert.SerializeObject(config, Formatting.Indented);

        File.WriteAllText(configFilePath, configJson);
    }
}