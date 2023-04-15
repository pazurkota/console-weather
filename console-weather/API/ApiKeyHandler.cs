using Newtonsoft.Json.Linq;
using static console_weather.API.JsonHandler;

namespace console_weather.API; 

public class ApiKeyHandler {
    // Get API Key from config.json
    public static string? GetApiKey() {
        var filePath = CONFIGPATH;
        
        if (!File.Exists(filePath)) {
            CreateConfigJsonFile();
        }
        
        var jsonText = File.ReadAllText(filePath);
        
        JObject config = JObject.Parse(jsonText);
        string? key = config["api-key"]?.ToString();

        return key;
    }
    
    // Set API Key 
    public static string? SetApiKey() {
        string filePath = CONFIGPATH;

        Console.Write("\nYour API Key is invalid or missing." +
                      "\nGet your personal key here: https://www.weatherapi.com" +
                      "\nAPI Key > ");
        
        string apiKey = Console.ReadLine()!;
        string configText = File.ReadAllText(filePath);

        JObject config = JObject.Parse(configText);
        config["api-key"] = apiKey;
        
        File.WriteAllText(filePath, config.ToString());

        return GetApiKey();
    }
}