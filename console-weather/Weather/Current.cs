using Newtonsoft.Json;

namespace console_weather.Weather; 

// Get weather conditon
public class Condition {
    [JsonProperty("text")]
    public string ConditionState { get; set; }
}

// Get current weather state
public class Current {
    [JsonProperty("temp_c")]
    public decimal Temperature { get; set; }
    public Condition Condition { get; set; }
    
    [JsonProperty("wind_kph")]
    public decimal WindSpeed { get; set; }
    
    [JsonProperty("wind_dir")]
    public string WindDirection { get; set; }
    
    [JsonProperty("pressure_mb")]
    public decimal Pressure { get; set; }
    
    [JsonProperty("humidity")]
    public int Humidity { get; set; }
    
    [JsonProperty("cloud")]
    public int Cloud { get; set; }
}