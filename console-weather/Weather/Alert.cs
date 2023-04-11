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
    public List<Alert> WeatherAlerts { get; set; }
}