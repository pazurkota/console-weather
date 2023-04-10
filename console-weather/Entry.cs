namespace console_weather.Controller; 

public class Entry {
    public static string GetCityName() {
        string cityName = Console.ReadLine() ?? string.Empty;
        return cityName;
    }
}