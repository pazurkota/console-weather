using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using console_weather.API;
using static console_weather.Settings;

namespace console_weather;

public class Program {
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

        var rootCommand = new RootCommand() {
            cityOption,
            alertsOption,
            forecastOption
        };
        rootCommand.SetHandler(OnHandle, cityOption, alertsOption, forecastOption);

        var commandLineBuilder = new CommandLineBuilder(rootCommand)
            .UseDefaults();
        var parser = commandLineBuilder.Build();

        return await parser.InvokeAsync(args).ConfigureAwait(false);
    }

    private static void OnHandle(string str, bool showAlerts, bool showForecast) {
        str ??= "auto:ip";
        
        CityName = str;
        DontShowAlerts = showAlerts;
        ShowForecast = showForecast;
        
        // Parse and show data
        ApiData data = new ApiData();
        Console.WriteLine(data.ParseData());
    }
}