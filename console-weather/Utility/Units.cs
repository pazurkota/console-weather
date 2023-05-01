namespace console_weather.Utility;

public class Units {
  public static string Degrees { get; set; } = null!;
  public static string Speed { get; set; } = null!;
  public static string Lenght { get; set; } = null!;

  public static void GetUnits() {
    string str = Settings.Units;

    switch (str) {
      case "si":
        Degrees = "°C";
        Speed = "m/s";
        Lenght = "kilometers";
        break;
      case "us":
        Degrees = "°F";
        Speed = "mph";
        Lenght = "miles";
        break;
      case "uk":
        Degrees = "°C";
        Speed = "mph";
        Lenght = "kilometers";
        break;
      case "eu":
        Degrees = "°C";
        Speed = "kph";
        Lenght = "kilometers";
        break;
      default:
        Console.Error.WriteLine("Error: unknown units");
        break;
    }
  }
}