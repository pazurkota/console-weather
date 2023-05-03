using console_weather.API;

namespace console_weather.Utility; 

public static class PrintData {
    public static string Print() {
        string str = "";
        
        var data = ApiData.ParseData();
        var unitType = new Units(Settings.Units);

        str += $"Current weather for {data.Location.Name} in {data.Location.Country} is {data.Current.Condition.ConditionState}\n";
        
        // print temperature
        if (unitType.Unit == Units.UnitType.Us) {
            str += $"The temperature is {data.Current.TemperatureF}°F, but feels like {data.Current.FeelsLikeF}°F\n\n";
        }
        else {
            str += $"The temperature is {data.Current.TemperatureC}°C, but feels like {data.Current.FeelsLikeC}°C\n\n";
        }
        
        str += $"{ShowAlerts()}";
        
        // print wind speed
        switch (unitType.Unit) {
            case Units.UnitType.Si:
                str += $"Current Wind Speed is {data.Current.WindSpeedKph * 1000/3600} m/s\n";
                break;
            case Units.UnitType.Eu:
                str += $"Current Wind Speed is {data.Current.WindSpeedKph} kph\n";
                break;
            case Units.UnitType.Us:
                str += $"Current Wind Speed is {data.Current.WindSpeedMph} mph\n";
                break;
            case Units.UnitType.Uk:
                str += $"Current Wind Speed is {data.Current.WindSpeedMph} mph\n";
                break;
        }
        
        str += $"Current Air Pressure is {data.Current.PressureMb} mbar\n";
        str += $"Current Humidity is {data.Current.Humidity}%\n";
        str += $"Current Cloud Cover is {data.Current.Cloud}%\n";
        str += $"Last Update: {data.Current.LastUpdated}";
        str += $"{ShowForecast()}";
        
        return str;
    }

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
        str += $"\nThe temperature range will be around {forecast.MinTemp}°C to {forecast.MaxTemp}°C, with average of {forecast.AvgTemp}°C";
        str += $"\nThe maximum wind speed will be around {forecast.MaxWindSpeed} kph";
        str += $"\nThe chance of rain/snow: {forecast.ChanceOfRain}% / {forecast.ChanceOfSnow}%";
        
        return str;
    }
}