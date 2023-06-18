using Newtonsoft.Json.Linq;
using console_weather.API;

namespace console_weather.Utility; 

public class DefaultSettings {
    private static string GetJsonContent() {
        string filePath = JsonHandler.Configpath;
        
        if (!File.Exists(filePath)) {
            JsonHandler.CreateConfigJsonFile();
        }
        
        string jsonText = File.ReadAllText(filePath);
        return jsonText;
    }

    public static bool DontShowAlerts() {
        JObject jObject = JObject.Parse(GetJsonContent());
        bool dontShowAlerts = jObject["dont-show-alerts"]?.ToObject<bool>() ?? false;

        return dontShowAlerts;
    }
}