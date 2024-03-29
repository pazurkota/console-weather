﻿using Newtonsoft.Json;

namespace console_weather.Weather; 

public class Alert {
    [JsonProperty("headline")] public string AlertHeadline { get; set; } = null!;
    [JsonProperty("desc")] public string AlertDescription { get; set; } = null!;
}

public class Alerts {
    [JsonProperty("alert")] public List<Alert> WeatherAlerts { get; set; } = null!;
}