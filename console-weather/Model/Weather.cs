using Newtonsoft.Json;

namespace console_weather.Model;

// Get location name and time
public class Location {
    public string Name { get; set; }
    public string Country { get; set; }
}

public class Condition {
    [JsonProperty("text")]
    public string ConditionState { get; set; }
}

// Get current weather condition
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

// Weather class itself
public class Weather {
    public Location Location;
    public Current Current;

    public override string ToString() {
        string str = $"Weather for {Location.Name}, {Location.Country} at {DateTime.Now}";

        str += $"\n\nTeperature: {Current.Temperature}°C ({Current.Condition.ConditionState})";
        str += $"\nWind Speed: {Current.WindSpeed}kmp ({Current.WindDirection})";
        str += $"\nAir Pressure: {Current.Pressure} mbar";
        str += $"\nHumidity: {Current.Humidity}%";
        str += $"\nCloud Cover: {Current.Cloud}%";

        return str;
    }
}