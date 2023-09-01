using Newtonsoft.Json;

namespace console_weather.Weather; 

public class Location {
    [JsonProperty("name")] public string Name { get; set; } = null!;
    [JsonProperty("country")] public string Country { get; set; } = null!;
    
    [JsonProperty("localtime")] public string LocalTime { get; set; } = null!;
}