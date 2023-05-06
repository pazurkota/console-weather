using console_weather.API;

namespace console_weather.Utility; 

public static class PrintData {

    private static readonly Units Units = new (Settings.Units);
    private static readonly Weather.Weather Data = ApiData.ParseData();
    
    public static string Print() {
        string str = "";
        
        var data = ApiData.ParseData();
        var unitType = new Units(Settings.Units);

        str += $"Current weather for {data.Location.Name} in {data.Location.Country} is {data.Current.Condition.ConditionState}\n";
        str += $"{ShowTemperature(unitType, data)}";
        str += $"{ShowAlerts()}";
        str += $"Current Wind Speed is {ShowWindSpeed(unitType, data)} {data.Current.WindDirection}\n";
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
                return $"{Math.Round(data.Current.WindSpeedKph * 1000/3600, 1)} m/s";
            case Units.UnitType.Eu:
                return $"{data.Current.WindSpeedKph} kph";
            default:
                return $"{data.Current.WindSpeedMph} mph";
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
        str += $"{ShowForecastTemp(Units, Data)}";
        str += $"\nThe maximum wind speed will be around {ShowForecastWindSpeed(Units, Data)}";
        str += $"\nThe chance of rain/snow: {forecast.ChanceOfRain}% / {forecast.ChanceOfSnow}%";
        
        return str;
    }

    #region Print forecast data

    private static string ShowForecastTemp(Units unitType, Weather.Weather data) {
        var forecast = data
            .Forecast
            .ForecastsDay[0]
            .Day;
        
        if (unitType.Unit == Units.UnitType.Us) {
            return $"\nThe temperature range will be around {forecast.MinTempF}°F to {forecast.MaxTempF}°F, with average of {forecast.AvgTempF}°F";
        }
        
        return $"\nThe temperature range will be around {forecast.MinTempC}°C to {forecast.MaxTempC}°C, with average of {forecast.AvgTempC}°C";
    }

    private static string ShowForecastWindSpeed(Units unitType, Weather.Weather data) {
        var forecast = data
            .Forecast
            .ForecastsDay[0]
            .Day;
        
        switch (unitType.Unit) {
            case Units.UnitType.Si:
                return $"{Math.Round(forecast.MaxWindSpeedKph * 1000/3600, 1)} m/s";
            case Units.UnitType.Eu:
                return $"{forecast.MaxWindSpeedKph} kph";
            default:
                return $"{forecast.MaxWindSpeedMph} mph";
        }
    }

    #endregion
}