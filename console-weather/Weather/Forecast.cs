using Newtonsoft.Json;

namespace console_weather.Weather; 

public class Forecast {
    [JsonProperty("forecastday")]
    public Condition ForecastDay { get; set; }
}

public class Forecasts {
    [JsonProperty("forecast")]
    public List<Forecast> ForecastsDay { get; set; }
}