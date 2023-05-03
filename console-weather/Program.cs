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
            "Set weather units"
        ); 

        var rootCommand = new RootCommand() {
            cityOption,
            alertsOption,
            forecastOption,
            unitsOption
        };
        rootCommand.SetHandler(OnHandle, cityOption, alertsOption, forecastOption, unitsOption);

        var commandLineBuilder = new CommandLineBuilder(rootCommand)
            .UseDefaults();
        var parser = commandLineBuilder.Build();

        return await parser.InvokeAsync(args).ConfigureAwait(false);
    }

    private static void OnHandle(string cityName, bool showAlerts, bool showForecast, Units.UnitType units) {
        cityName ??= "auto:ip";
        
        CityName = cityName;
        DontShowAlerts = showAlerts;
        ShowForecast = showForecast;
        Settings.Units = units;

        // Parse and show data
        Console.WriteLine(PrintData.Print());
    }
}