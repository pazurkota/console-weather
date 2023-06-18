using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using console_weather.Utility;
using static console_weather.Utility.Settings;
using Units = console_weather.Utility.Units;

namespace console_weather;

public static class Program {
    public static async Task<int> Main(string[] args) {
        var cityOption = new Option<string>(
            new [] {"-c", "--city"},
            "Get city name"
        );

        var alertsOption = new Option<bool>(
            "--no-alerts",
            () => false,
            "Hide weather alerts"
        );

        var forecastOption = new Option<bool>(
            new []{"--forecast", "-f"},
            () => false,
            "Show weather forecast"
        );

        var unitsOption = new Option<Units.UnitType>(
            new []{"--units", "-u"},
            () => Units.UnitType.Eu,
            "Set weather units"
        );

        var airQualityOption = new Option<bool>(
            new []{"--air-quality", "-a"},
            () => false,
            "Show air quality"
        );
        
        var iconsOption = new Option<bool>(
            new []{"--dont-show-icons"},
            () => false,
            "Disable weather icons"
        );

        var rootCommand = new RootCommand {
            cityOption,
            alertsOption,
            forecastOption,
            unitsOption,
            airQualityOption,
            iconsOption
        };
        rootCommand.SetHandler(OnHandle, cityOption, alertsOption, forecastOption, unitsOption, airQualityOption, iconsOption);

        var commandLineBuilder = new CommandLineBuilder(rootCommand)
            .UseDefaults();
        var parser = commandLineBuilder.Build();

        return await parser.InvokeAsync(args).ConfigureAwait(false);
    }

    private static void OnHandle(string cityName, bool showAlerts, bool showForecast, Units.UnitType units, bool airQuality, bool showIcons) {
        CityName = cityName ?? "auto:ip";
        DontShowAlerts = showAlerts || DefaultSettings.DontShowAlerts();
        ShowForecast = showForecast;
        Settings.Units = units;
        ShowAirQuality = airQuality;
        DontShowIcons = showIcons;

        // Parse and show data
        Console.WriteLine(PrintData.Print());
    }
}