﻿using Newtonsoft.Json;

namespace console_weather.Weather; 

// Get Location info
public class Location {
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("country")]
    public string Country { get; set; }
}