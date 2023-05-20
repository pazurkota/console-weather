namespace console_weather.Utility;

public struct Settings {
    public static string CityName { get; set; } = null!;
    public static bool DontShowAlerts { get; set; }
    public static bool ShowForecast { get; set; }
    public static Units.UnitType Units { get; set; }
    public static bool ShowAirQuality { get; set; }
}