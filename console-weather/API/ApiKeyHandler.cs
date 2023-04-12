using Newtonsoft.Json.Linq;

namespace console_weather.API; 

public class ApiKeyHandler {
    // Get API Key from config.json
    public static string GetApiKey() {
        var filePath = "config.json";
        
        // Check if file exist, and if not, throw error
        if (!File.Exists(filePath)) {
            throw new FileNotFoundException($"{filePath} has not been found!");
        }
        
        var jsonText = File.ReadAllText(filePath);

        JObject config = JObject.Parse(jsonText);

        string key = config["api-key"].ToString();
        return key;
    }
}