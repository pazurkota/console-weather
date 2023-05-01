namespace console_weather; 

public struct Settings {
    public static string CityName { get; set; } = null!;
    public static bool DontShowAlerts { get; set; }
    public static bool ShowForecast { get; set; }
    public static string Units { get; set; } = "si"; // default
}