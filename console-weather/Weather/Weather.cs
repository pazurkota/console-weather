namespace console_weather.Weather;

// Weather class itself
public class Weather {
    public Location Location;
    public Current Current;
    public Alerts Alerts;
    public Forecast Forecast;

    public override string ToString() {
        string str = $"The current weather for {Location.Name} in {Location.Country} is {Current.Condition.ConditionState}\n" +
                     $"The temperature is {Current.Temperature}°C, but feels like: {Current.FeelsLikeTemp}°C\n\n";

        str += $"{ShowAlerts()}";
        str += $"Current Wind speed is {Current.WindSpeed} kmp {Current.WindDirection}\n";
        str += $"Current Air Pressure is {Current.Pressure} mbar\n";
        str += $"Current Humidity is {Current.Humidity}%\n";
        str += $"Current Cloud Cover is {Current.Cloud}%\n";
        str += $"Last update: {Current.LastUpdated}\n";
        str += $"\n{ShowForecast()}";

        return str;
    }

    private string? ShowAlerts() {
        if (Settings.DontShowAlerts || Alerts.WeatherAlerts.Count == 0) {
            return null;
        }

        string str = "";
        
        foreach (var alert in Alerts.WeatherAlerts) {
            str += $"{alert.AlertHeadline}:\n{alert.AlertDescription}\n\n";
        }

        return str;
    }

    private string ShowForecast() {
        string maxTemp = Forecast.ForecastsDay[1].Day.MaxTemp.ToString();
        string minTemp = Forecast.ForecastsDay[1].Day.MinTemp.ToString();
        string avgTemp = Forecast.ForecastsDay[1].Day.MinTemp.ToString();

        string maxWind = Forecast.ForecastsDay[1].Day.MaxTemp.ToString();

        string chanceOfRain = Forecast.ForecastsDay[1].Day.ChanceOfRain.ToString();
        string chanceOfSnow = Forecast.ForecastsDay[1].Day.ChanceOfSnow.ToString();
        
        string str = $"Tomorrow it will be {Forecast.ForecastsDay[1].Day.Condition.ConditionState}"
            + $"\nThe temperature range will be around {minTemp}°C to {maxTemp}°C, with average of {avgTemp}°C"
            + $"\nThe maximum wind speed will be around {maxWind} kph" 
            + $"\nThe chance of rain/snow: {chanceOfRain}% / {chanceOfSnow}%";

        return str;
    }
}