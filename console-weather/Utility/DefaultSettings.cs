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

    public static bool ShowForecast() {
        JObject jObject = JObject.Parse(GetJsonContent());
        bool showForecast = jObject["show-forecast"]?.ToObject<bool>() ?? false;
        
        return showForecast;
    }
}