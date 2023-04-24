# ⛅ Console Weather project
Console Weather project is a simple application project to check weather in console. This project uses the [Weather API](https://www.weatherapi.com/) for best weather forecast



## Features

- Show Temperature and Weather Condition
- Show current Wind Speed and Direction
- Show Air Pressure, Humidity and Cloud Cover
- Show Weather Alerts (if exists)
- Show Weather Forecast (for a next day)



## Installation

If you installed [.NET 7.0 or newer](https://dotnet.microsoft.com/en-us/download), just simply paste this command into console:
```bash
dotnet tool install --global console-weather --version 1.2.0
```

If you want to update, just type:
```bash
dotnet tool update --global console-weather
```

If you running app first time, it will ask you for the [Weather API](https://www.weatherapi.com/):
``` 
Error: API returned status code Forbidden

Your API Key is invalid or missing.
Get your personal key here: https://www.weatherapi.com
API Key >
```
Enter your personal API key and enjoy using it!

The key is kept in `C:\Users\USERNAME\Documents\weather_data`
## Usage
To use application, just simply type:
```bash
weather
```
To get weather info from a specified city, type:
```bash
weather -c "City Name"
```

To get weather information without alerts, type:
```bash
weather --no-alerts
```

To get forecast for the next day, type:
```bash
weather -f
```

Full command list:
```bash
  -c, --city <city>  Get city name
  --no-alerts        Hide weather alerts [default: False]
  -f, --forecast     Show weather forecast [default: False]
  --version          Show version information
  -?, -h, --help     Show help and usage information
```


## Demo

Example input:
```
weather -c "Kansas City" --no-alerts
```

Example output:
```
The current weather for Kansas City in United States of America is Sunny
The temperature is 16,1°C, but feels like: 16,1°C

Current Wind speed is 16,9 kmp SSW
Current Air Pressure is 1020,0 mbar
Current Humidity is 33%
Current Cloud Cover is 0%
Last update: 2023-04-24 12:30
```
## Acknowledgements

- [NuGet Page](https://www.nuget.org/packages/console-weather/)


## License and support
This project is under [MIT License](https://github.com/pazurkota/console-weather/blob/master/LICENCE.md)

For any project-related cases, please contact me on Discord: pazurkota#1001


## Lessons Learned

This project basically was created to learn how to work with the API (in this case, weather API) and creating CLI apps using C#




