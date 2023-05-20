# ⛅ Console Weather project
Console Weather project is a simple application project to check weather in console. This project uses the [Weather API](https://www.weatherapi.com/) for best weather forecast



## Features

- Show Temperature and Weather Condition
- Show current Wind Speed and Direction
- Show Air Pressure, Humidity and Cloud Cover
- Show Weather Alerts (if exists)
- Show Weather Forecast (for a next day)
- Checking Air Quality



## Installation

If you installed [.NET 7.0 or newer](https://dotnet.microsoft.com/en-us/download), just simply paste this command into console:
```console
$ dotnet tool install --global console-weather --version 1.5.0
```

If you want to update, just type:
```console
$ dotnet tool update --global console-weather
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
```bash
# To use aplication, type:
$ weather

# To get weather info from a specified city, type:
$ weather -c "Warsaw"

# To get weather information without alerts, type:
$ weather --no-alerts

# To get forecast for the next day, type:
$ weather -f

# To use specific units, type:
$ weather -u Si

# To get air quality data, type:
$ weather -a
```

## Demo
```bash
# Show weather for London with forecast and air quality data
$ weather -c "London" -f -a

# CURRENT WEATHER:
# Current weather for London in United Kingdom is Partly cloudy
# The temperature is 19,0°C, but feels like 19,0°C
#
# Current Wind Speed: 22,0 kph (NE)
# Current Air Pressure: 1024,0 mbar
# Current Visibility: 10,0 kilometers
# Current Precipitation: 0,0 mm
# Current Humidity: 46%
# Current Cloud Cover: 50%
# Current UV Index: 5,0 (Moderate)

# FORECAST:
# Tomorrow it will be Cloudy
# Temperature Range: 7,9°C - 17,7°C (average: 13,2)°C
# Maximum Wind Speed: 19,8 kph
# Average Visibility: 10,0 kilometers
# Maximum Precipitation: 0,0 mm
# UV Index: 3,0 (Moderate)
# Chance of rain/snow: 0% / 0%
#
# AIR QUALITY:
# Carbon Monoxide: 205,30 ug/m3
# Nitrogen Dioxide: 4,40 ug/m3
# Ozone: 113,0 ug/m3
# Sulphur Dioxide: 3,30 ug/m3
# Fine Particles Matter: 4,40 ug/m3
# Coarse Particles Matter: 7,5 ug/m3
# US Epa Index: 1 (Good)
# 
# Last Update: 2023-05-20 14:45
```

## Acknowledgements

- [NuGet Page](https://www.nuget.org/packages/console-weather/)


## License and support
This project is under [MIT License](https://github.com/pazurkota/console-weather/blob/master/LICENCE.md)

For any project-related cases, please contact me on Discord: pazurkota#1001


## Lessons Learned

This project basically was created to learn how to work with the API (in this case, weather API) and creating CLI apps using C#
