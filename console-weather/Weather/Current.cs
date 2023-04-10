using Newtonsoft.Json;

namespace console_weather.Weather;

// Get current weather state
public class Current {
    public Condition Condition { get; set; }
    
    [JsonProperty("last_updated")]
    public string LastUpdated { get; set; }

    [JsonProperty("temp_c")]
    public decimal Temperature { get; set; }
    
    [JsonProperty("feelslike_c")]
    public decimal FeelsLikeTemp { get; set; }

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