using console_weather.API;

namespace console_weather.Utility; 

public static class PrintData {
    public static string Print() {
        string str = "";
        
        var data = ApiData.ParseData();
        var unitType = new Units(Settings.Units);

        str += $"Current weather for {data.Location.Name} in {data.Location.Country} is {data.Current.Condition.ConditionState}\n";
        str += $"{ShowTemperature(unitType, data)}";
        str += $"{ShowAlerts()}";
        str += $"{ShowWindSpeed(unitType, data)} {data.Current.WindDirection}\n";
        str += $"Current Air Pressure is {data.Current.PressureMb} mbar\n";
        str += $"Current Humidity is {data.Current.Humidity}%\n";
        str += $"Current Cloud Cover is {data.Current.Cloud}%\n";
        str += $"Last Update: {data.Current.LastUpdated}";
        str += $"{ShowForecast()}";
        
        return str;
    }

    #region Print weather data

    private static string ShowTemperature(Units unitType, Weather.Weather data) {
        if (unitType.Unit == Units.UnitType.Us) {
            return $"The temperature is {data.Current.TemperatureF}°F, but feels like {data.Current.FeelsLikeF}°F\n\n";
        }
        
        return $"The temperature is {data.Current.TemperatureC}°C, but feels like {data.Current.FeelsLikeC}°C\n\n";
    }

    private static string ShowWindSpeed(Units unitType, Weather.Weather data) {
        switch (unitType.Unit) {
            case Units.UnitType.Si:
                return $"Current Wind Speed is {Math.Round(data.Current.WindSpeedKph * 1000/3600, 1)} m/s";
            case Units.UnitType.Eu:
                return $"Current Wind Speed is {data.Current.WindSpeedKph} kph";
            default:
                return $"Current Wind Speed is {data.Current.WindSpeedMph} mph";
        }
    }

    #endregion
    
    private static string? ShowAlerts() {
        var alerts = ApiData.ParseData().Alerts;

        if (Settings.DontShowAlerts || alerts.WeatherAlerts.Count == 0) {
            return null;
        }

        string str = "";

        foreach (var alert in alerts.WeatherAlerts) {
            str += $"{alert.AlertHeadline}:\n{alert.AlertDescription}\n\n";
        }
        
        return str;
    }

    private static string? ShowForecast() {
        if (!Settings.ShowForecast) {
            return null;
        }

        string str = "";
        
        var forecast = ApiData.ParseData()
            .Forecast
            .ForecastsDay[0]
            .Day;

        str += $"\n\nTomorrow it will be {forecast.Condition.ConditionState}";
        str += $"\nThe temperature range will be around {forecast.MinTempC}°C to {forecast.MaxTempC}°C, with average of {forecast.AvgTempC}°C";
        str += $"\nThe maximum wind speed will be around {forecast.MaxWindSpeedKph} kph";
        str += $"\nThe chance of rain/snow: {forecast.ChanceOfRain}% / {forecast.ChanceOfSnow}%";
        
        return str;
    }
}