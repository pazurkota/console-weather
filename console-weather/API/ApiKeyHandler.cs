using Newtonsoft.Json.Linq;

namespace console_weather.API; 

public class ApiKeyHandler {
    // Get API Key from config.json
    public static string? GetApiKey() {
        var filePath = "config.json";
        var jsonText = File.ReadAllText(filePath);
        
        JObject config = JObject.Parse(jsonText);
        string? key = config["api-key"]?.ToString();

        return key;
    }
    
    // Set API Key 
    public static string? SetApiKey() {
        string filePath = "config.json";
        
        // Check if file exist, and if not, create one
        if (!File.Exists(filePath)) {
            File.Create(filePath);
        }
        
        Console.Write("\nPlease input API Key here:\nAPI Key > ");
        
        string apiKey = Console.ReadLine()!;
        string configText = File.ReadAllText(filePath);

        JObject config = JObject.Parse(configText);
        config["api-key"] = apiKey;
        
        File.WriteAllText(filePath, config.ToString());

        return GetApiKey();
    }
}