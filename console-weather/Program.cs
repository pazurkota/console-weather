using System.CommandLine;
using console_weather.Utility;
using static console_weather.Utility.Settings;
using Units = console_weather.Utility.Units;

namespace console_weather;

public static class Program {
    public static async Task<int> Main(string[] args) {
        var cityOption = new Option<string>("--city", new[] {"-c"}) {
            Description = "Get city name"
        };

        var alertsOption = new Option<bool>("--no-alerts") {
            DefaultValueFactory = _ => DefaultSettings.DontShowAlerts(),
            Description = "Hide weather alerts"
        };

        var forecastOption = new Option<bool>("--forecast", new[] {"-f"}) {
            DefaultValueFactory = _ => DefaultSettings.ShowForecast(),
            Description = "Show weather forecast"
        };

        var unitsOption = new Option<Units.UnitType>("--units", new[] {"-u"}) {
            DefaultValueFactory = _ => DefaultSettings.GetUnitType(),
            Description = "Set weather units"
        };

        var airQualityOption = new Option<bool>("--air-quality", new[] {"-a"}) {
            DefaultValueFactory = _ => DefaultSettings.GetAirQuality(),
            Description = "Show air quality"
        };

        var iconsOption = new Option<bool>("--dont-show-icons") {
            DefaultValueFactory = _ => DefaultSettings.DontShowIcons(),
            Description = "Disable weather icons"
        };
        
        var astronomyOption = new Option<bool>("--astronomy", new[] {"-as"}) {
            DefaultValueFactory = _ => DefaultSettings.ShowAstronomy(),
            Description = "Show astronomy data"
        };
        
        var hourlyWeatherOption = new Option<bool>("--hourly-weather", new[] {"-hw"}) {
            DefaultValueFactory = _ => DefaultSettings.ShowHourlyWeather(),
            Description = "Show hourly weather"
        };

        var rootCommand = new RootCommand {
            cityOption,
            alertsOption,
            forecastOption,
            unitsOption,
            airQualityOption,
            iconsOption,
            astronomyOption,
            hourlyWeatherOption
        };
        rootCommand.SetAction(parseResult => OnHandle(
            parseResult.GetValue(cityOption),
            parseResult.GetValue(alertsOption),
            parseResult.GetValue(forecastOption),
            parseResult.GetValue(unitsOption),
            parseResult.GetValue(airQualityOption),
            parseResult.GetValue(iconsOption),
            parseResult.GetValue(astronomyOption),
            parseResult.GetValue(hourlyWeatherOption)));

        return await rootCommand.Parse(args).InvokeAsync();
    }

    private static void OnHandle(string cityName,bool showAlerts,bool showForecast, 
        Units.UnitType units, bool airQuality, bool showIcons, bool showAstronomy, bool showHourlyWeather) {
        
        CityName = cityName ?? DefaultSettings.GetCityName();
        DontShowAlerts = showAlerts;
        ShowForecast = showForecast;
        Settings.Units = units;
        ShowAirQuality = airQuality;
        DontShowIcons = showIcons;
        ShowAstronomy = showAstronomy;
        ShowHourlyWeather = showHourlyWeather;

        // Parse and show data
        Console.WriteLine(PrintData.Print());
    }
}