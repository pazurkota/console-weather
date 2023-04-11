using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

public class Program {
    public static async Task<int> Main(string[] args) {
        var cityOption = new Option<string>(
            new [] {"-c", "--city"},
            "Get city name"
        );

        var rootCommand = new RootCommand() {
            cityOption
        };
        rootCommand.SetHandler(OnHandle, cityOption);

        var commandLineBuilder = new CommandLineBuilder(rootCommand)
            .UseDefaults();
        var parser = commandLineBuilder.Build();

        return await parser.InvokeAsync(args).ConfigureAwait(false);
    }

    private static void OnHandle(string str) => 
        Console.WriteLine($"{str}");
}