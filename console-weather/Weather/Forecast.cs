﻿using Newtonsoft.Json;

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

    public override string ToString() {
        if (!Settings.ShowForecast) {
            return null;
        }

        string conditionState = ForecastsDay[1].Day.Condition.ConditionState;
        
        string maxTemp = ForecastsDay[1].Day.MaxTemp.ToString();
        string minTemp = ForecastsDay[1].Day.MinTemp.ToString();
        string avgTemp = ForecastsDay[1].Day.AvgTemp.ToString();

        string maxWind = ForecastsDay[1].Day.MaxTemp.ToString();

        string chanceOfRain = ForecastsDay[1].Day.ChanceOfRain.ToString();
        string chanceOfSnow = ForecastsDay[1].Day.ChanceOfSnow.ToString();
        
        string str = $"\n\nTomorrow it will be {conditionState}"
                     + $"\nThe temperature range will be around {minTemp}°C to {maxTemp}°C, with average of {avgTemp}°C"
                     + $"\nThe maximum wind speed will be around {maxWind} kph" 
                     + $"\nThe chance of rain/snow: {chanceOfRain}% / {chanceOfSnow}%";

        return str;
    }
}