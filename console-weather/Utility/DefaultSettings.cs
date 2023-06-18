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

    public static Units.UnitType GetUnitType() {
        JObject jObject = JObject.Parse(GetJsonContent());
        string unitType = jObject["units"]?.ToObject<string>()?.ToLower() ?? "eu";
        
        return unitType switch {
            "eu" => Units.UnitType.Eu,
            "us" => Units.UnitType.Us,
            "si" => Units.UnitType.Si,
            "uk" => Units.UnitType.Uk,
            _ => Units.UnitType.Eu
        };
    }
    
    public static bool GetAirQuality() {
        JObject jObject = JObject.Parse(GetJsonContent());
        bool airQuality = jObject["air-quality"]?.ToObject<bool>() ?? false;
        
        return airQuality;
    }
    
    public static bool DontShowIcons() {
        JObject jObject = JObject.Parse(GetJsonContent());
        bool dontShowIcons = jObject["dont-show-icons"]?.ToObject<bool>() ?? false;
        
        return dontShowIcons;
    }

    public static string GetCityName() {
        JObject jObject = JObject.Parse(GetJsonContent());
        string cityName = jObject["default-city"]?.ToObject<string>() ?? "auto:ip";
        
        return cityName;
    }
}