namespace console_weather.Model; 

public class Weather {
    public string City { get; set; }
    public int Temperature { get; set; } 
    public string WeatherCondition { get; set; }
    public string AlertHeadline { get; set; }

    public override string ToString() {
        return $"Weather for: {City}" +
               $"\nTemperature: {Temperature}°C" +
               $"\nWeather Condition: {WeatherCondition}" +
               $"\nAlert: {AlertHeadline}";
    }
}