using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using console_weather;
using console_weather.API;

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
            "Show weather alerts"
        );

        var rootCommand = new RootCommand() {
            cityOption,
            alertsOption
        };
        rootCommand.SetHandler(OnHandle, cityOption, alertsOption);

        var commandLineBuilder = new CommandLineBuilder(rootCommand)
            .UseDefaults();
        var parser = commandLineBuilder.Build();

        return await parser.InvokeAsync(args).ConfigureAwait(false);
    }

    private static void OnHandle(string str, bool showAlerts) {
        // Get city name from IP address if city name not provided
        str ??= "auto:ip";
        
        ApiData.CITYNAME = str;
        ApiData data = new ApiData();
        
        Console.WriteLine(data.ParseData());
    }
}