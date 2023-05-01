namespace console_weather.Weather;

// Weather class itself
public class Weather {
    public Location Location;
    public Current Current;
    public Alerts Alerts;
    public Forecast Forecast;

    public override string ToString() {
        string str = $"The current weather for {Location.Name} in {Location.Country} is {Current.Condition.ConditionState}\n" +
                     $"The temperature is {Current.TemperatureC}°C, but feels like: {Current.FeelsLikeC}°C\n\n";

        str += $"{Alerts}";
        str += $"Current Wind speed is {Current.WindSpeedKph} kmp {Current.WindDirection}\n";
        str += $"Current Air Pressure is {Current.PressureMb} mbar\n";
        str += $"Current Humidity is {Current.Humidity}%\n";
        str += $"Current Cloud Cover is {Current.Cloud}%\n";
        str += $"Last update: {Current.LastUpdated}";
        str += $"{Forecast}";

        return str;
    }
}