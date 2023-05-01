using Newtonsoft.Json;

namespace console_weather.Weather; 

public class ForecastDay {
    [JsonProperty("date")] public string Date { get; set; } = null!;
    [JsonProperty("day")] public Day Day { get; set; } = null!;
}

public class Day {
    [JsonProperty("avgtemp_c")] public decimal AvgTemp { get; set; }
    [JsonProperty("maxtemp_c")] public decimal MaxTemp { get; set; }
    [JsonProperty("mintemp_c")] public decimal MinTemp { get; set; }
    [JsonProperty("maxwind_kph")] public decimal MaxWindSpeed { get; set; }
    [JsonProperty("daily_chance_of_rain")] public decimal ChanceOfRain { get; set; }
    [JsonProperty("daily_chance_of_snow")] public decimal ChanceOfSnow { get; set; }
    [JsonProperty("condition")] public Condition Condition { get; set; } = null!;
}

public class Forecast {
    [JsonProperty("forecastday")] public List<ForecastDay> ForecastsDay { get; set; } = null!;
}