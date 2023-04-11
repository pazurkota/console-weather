namespace console_weather.Weather;

// Weather class itself
public class Weather {
    public Location Location;
    public Current Current;
    public Alerts Alerts;

    public override string ToString() {
        string str = $"Weather for {Location.Name}, {Location.Country} (last update: {Current.LastUpdated}):";

        str += $"\n\nTeperature: {Current.Temperature}°C (feels like: {Current.FeelsLikeTemp}°C)";
        str += $"\nWeather Condition: {Current.Condition.ConditionState}";
        str += $"\nWind Speed: {Current.WindSpeed}kmp ({Current.WindDirection})";
        str += $"\nAir Pressure: {Current.Pressure} mbar";
        str += $"\nHumidity: {Current.Humidity}%";
        str += $"\nCloud Cover: {Current.Cloud}%";
        str += $"\n\nWeather Alerts: {Alerts.WeatherAlerts[0].AlertEvent}";

        return str;
    }
}