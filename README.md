# ⛅ Console Weather project
Console Weather project is a simple application project to check weather in console. This project uses the [Weather API](https://www.weatherapi.com/) for best weather forecast



## Features

- Show Temperature and Weather Condition
- Show current Wind Speed and Direction
- Show Air Pressure, Humidity and Cloud Cover
- Show Weather Alerts (if exists)



## Installation

If you installed [.NET 7.0 or newer](https://dotnet.microsoft.com/en-us/download), just simply paste this command into console:
```bash
dotnet tool install --global console-weather --version 1.1.0
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
weather -c "City Name"
```


## Demo

Example input:
```bash
weather -c "London"
```

Example output:
```
Weather for London, United Kingdom (last update: 2023-04-15 16:00):

Teperature: 14,0°C (feels like: 13,7°C)
Weather Condition: Partly cloudy
Wind Speed: 13,0kmp (WNW)
Air Pressure: 1021,0 mbar
Humidity: 59%
Cloud Cover: 25%

Weather Alerts:
<none>
```
## Acknowledgements

 - [NuGet Package page](https://www.nuget.org/packages/console-weather/)


## License and support
This project is under [MIT License](https://github.com/pazurkota/console-weather/blob/master/LICENCE.md)

For any project-related cases, please contact me on Discord: pazurkota#1001


## Lessons Learned

This project basically was created to learn how to work with the API (in this case, weather API) and creating CLI apps using C#
