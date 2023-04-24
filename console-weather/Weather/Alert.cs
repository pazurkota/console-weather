using Newtonsoft.Json;

namespace console_weather.Weather; 

// A single Alert Class
public class Alert {
    [JsonProperty("headline")]
    public string AlertHeadline { get; set; }
    [JsonProperty("event")]
    public string AlertEvent { get; set; }
    [JsonProperty("desc")]
    public string AlertDescription { get; set; }
}

// A class for multiple weather alerts
public class Alerts {
    [JsonProperty("alert")]
    public List<Alert> WeatherAlerts { get; set; }

    public override string ToString() {
        if (Settings.DontShowAlerts || WeatherAlerts.Count == 0) {
            return null;
        }

        string str = "";
        
        foreach (var alert in WeatherAlerts) {
            str += $"{alert.AlertHeadline}:\n{alert.AlertDescription}\n\n";
        }

        return str;
    }
}