using Newtonsoft.Json;
using console_weather.Utility;

namespace console_weather.Weather; 

public class ForecastDay {
    [JsonProperty("day")] public Day Day { get; set; } = null!;
    [JsonProperty("astro")] public Astro Astro { get; set; } = null!;
    [JsonProperty("hour")] public List<Hour> Hours { get; set; } = null!;
}

public class Day {
    // celsius
    [JsonProperty("avgtemp_c")] public decimal AvgTempC { get; set; }
    [JsonProperty("maxtemp_c")] public decimal MaxTempC { get; set; }
    [JsonProperty("mintemp_c")] public decimal MinTempC { get; set; }
    
    // fahrenheit
    [JsonProperty("avgtemp_f")] public decimal AvgTempF { get; set; }
    [JsonProperty("maxtemp_f")] public decimal MaxTempF { get; set; }
    [JsonProperty("mintemp_f")] public decimal MinTempF { get; set; }
    
    // visibility
    [JsonProperty("avgvis_km")] public decimal AvgVisibilityKm { get; set; }
    [JsonProperty("avgvis_miles")] public decimal AvgVisibilityMiles { get; set; }
    
    [JsonProperty("maxwind_kph")] public decimal MaxWindSpeedKph { get; set; }
    [JsonProperty("maxwind_mph")] public decimal MaxWindSpeedMph { get; set; }
    
    [JsonProperty("totalprecip_mm")] public decimal PrecipitationMm { get; set; }
    [JsonProperty("totalprecip_in")] public decimal PrecipitationIn { get; set; }
    
    [JsonProperty("daily_chance_of_rain")] public decimal ChanceOfRain { get; set; }
    [JsonProperty("daily_chance_of_snow")] public decimal ChanceOfSnow { get; set; }
    
    [JsonProperty("uv")] public decimal UvIndex { get; set; }
    
    [JsonProperty("condition")] public Condition Condition { get; set; } = null!;
}

public class Hour {
    [JsonProperty("time")] public string Time { get; set; } = null!;
    [JsonProperty("condition")] public Condition Condition { get; set; } = null!;
    
    [JsonProperty("temp_c")] public decimal TemperatureC { get; set; }
    [JsonProperty("temp_f")] public decimal TemperatureF { get; set; }
    
    public decimal Temperature => Settings.Units switch {
        Units.UnitType.Si => TemperatureC,
        Units.UnitType.Eu => TemperatureC,
        _ => TemperatureF
    };
}

public class Astro {
    [JsonProperty("sunrise")] public string Sunrise { get; set; }
    [JsonProperty("sunset")] public string Sunset { get; set; }
    [JsonProperty("moonrise")] public string Moonrise { get; set; }
    [JsonProperty("moonset")] public string Moonset { get; set; }
    [JsonProperty("moon_phase")] public string MoonPhase { get; set; }
    [JsonProperty("moon_illumination")] public string MoonIllumination { get; set; }
}

public class Forecast {
    [JsonProperty("forecastday")] public List<ForecastDay> ForecastsDay { get; set; } = null!;
}