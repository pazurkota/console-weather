using Newtonsoft.Json.Linq;
using static console_weather.API.JsonHandler;

namespace console_weather.API; 

public static class ApiKeyHandler {
    public static string? GetApiKey() {
        var filePath = Configpath;
        
        if (!File.Exists(filePath)) {
            CreateConfigJsonFile();
        }
        
        var jsonText = File.ReadAllText(filePath);
        
        JObject config = JObject.Parse(jsonText);
        string? key = config["api-key"]?.ToString();

        return key;
    }
    
    public static void SetApiKey() {
        string filePath = Configpath;

        Console.Write("\nYour API Key is invalid or missing." +
                      "\nGet your personal key here: https://www.weatherapi.com" +
                      "\nAPI Key > ");
        
        string apiKey = Console.ReadLine()!;
        string configText = File.ReadAllText(filePath);

        JObject config = JObject.Parse(configText);
        config["api-key"] = apiKey;
        
        File.WriteAllText(filePath, config.ToString());
    }
}