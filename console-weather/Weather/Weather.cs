namespace console_weather.Weather;

// Weather class itself
public class Weather {
    public Location Location;
    public Current Current;
    public Alerts Alerts;

    public override string ToString() {
        string str = $"The current weather for {Location.Name} in {Location.Country} is {Current.Condition.ConditionState}\n" +
                     $"The temperature is {Current.Temperature}°C, but feels like: {Current.FeelsLikeTemp}°C\n\n";

        str += $"{ShowWeatherAlerts()}";
        str += $"Current Wind speed is {Current.WindSpeed} kmp {Current.WindDirection}\n";
        str += $"Current Air Pressure is {Current.Pressure} mbar\n";
        str += $"Current Humidity is {Current.Humidity}%\n";
        str += $"Current Cloud Cover is {Current.Cloud}%\n";
        str += $"Last update: {Current.LastUpdated}\n";

        return str;
    }

    private string? ShowWeatherAlerts() {
        if (Settings.DontShowAlerts || Alerts.WeatherAlerts.Count == 0) {
            return null;
        }

        string str = "";
        
        foreach (var alert in Alerts.WeatherAlerts) {
            str += $"{alert.AlertHeadline}:\n{alert.AlertDescription}\n\n";
        }

        return str;
    }
}