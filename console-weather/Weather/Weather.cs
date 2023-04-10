using console_weather.Model;

namespace console_weather.Weather;

// Weather class itself
public class Weather {
    public Location Location;
    public Current Current;

    public override string ToString() {
        string str = $"Weather for {Location.Name}, {Location.Country} at {DateTime.Now}";

        str += $"\n\nTeperature: {Current.Temperature}°C ({Current.Condition.ConditionState})";
        str += $"\nWind Speed: {Current.WindSpeed}kmp ({Current.WindDirection})";
        str += $"\nAir Pressure: {Current.Pressure} mbar";
        str += $"\nHumidity: {Current.Humidity}%";
        str += $"\nCloud Cover: {Current.Cloud}%";

        return str;
    }
}