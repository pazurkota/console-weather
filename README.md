# ⛅ Console Weather project


![Release](https://img.shields.io/github/v/release/pazurkota/console-weather?include_prereleases&style=for-the-badge&logo=github)
![Repo Size](https://img.shields.io/github/repo-size/pazurkota/console-weather?logo=git&style=for-the-badge)
![Downloads](https://img.shields.io/nuget/dt/console-weather?style=for-the-badge&logo=nuget)
![License](https://img.shields.io/github/license/pazurkota/console-weather?style=for-the-badge)

Console Weather project is a simple application project to check weather in console. You can get it on [NuGet](https://www.nuget.org/packages/console-weather/) page



![App Screenshot](Images/readme_image.png)


## Features

- Show Temperature and Weather Condition
- Show current Wind Speed and Direction
- Show Air Pressure, Humidity and Cloud Cover
- Show Weather Alerts
- Show Weather Forecast for a next day
- Show Air Quality
- Show Weather Icons

## Installation

If you installed [.NET 7.0 or newer](https://dotnet.microsoft.com/en-us/download), just simply paste this command into console:
```console
$ dotnet tool install --global console-weather --version 1.7.1
```

If you want to update, just type:
```console
$ dotnet tool update --global console-weather
```
## Usage

### Commands:
```console
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

# To show weather without icons, type:
$ weather --dont-show-icons

# To show astronomical data, type:
$ weather --astronomy

# To show hourly weather forecast, type:
$ weather --hourly-weather
```

### Default settings:
This project uses default settings that are stored in `config.json` file. You can change them by editing this file:
```json
{
  "api-key": "api-key",
  "default-city": "Sydney",
  "dont-show-alerts": false,
  "show-forecast": false,
  "units": "EU",
  "air-quality": true,
  "dont-show-icons": false,
  "show-astronomy": false,
  "show-hourly-weather": false
}
```

- `"default-city"` - default city that will be used if you don't specify it in command
- `"dont-show-alerts"` - if set to `true`, weather alerts won't be shown
- `"show-forecast"` - if set to `true`, weather forecast will be shown
- `"units"` - units that will be used to show weather data. Possible values: `eu`, `si`, `us`, `uk`
- `"air-quality"` - if set to `true`, air quality data will be shown
- `"dont-show-icons"` - if set to `true`, weather icons won't be shown
- `"show-astronomy"` - if set to `true`, astronomical data will be shown
- `"show-hourly-weather"` - if set to `true`, hourly weather forecast (for 5 hours) will be shown

> **Note**: These settings is not required. You can use application without them.

The config file is kept in:
- Windows: `C:\Users\USERNAME\Documents\weather_data\config.json`
- MacOS: `/Users/USERNAME/Documents/weather_data/config.json`
- Linux: `/home/USERNAME/Documents/weather_data/config.json`


## Demo
```console
$ weather -c "Kansas City" --no-alerts -f -a

                :::
        .:      ===     .:.
       .===.    ===    .==-
         ==-           ==-
  .:.        .::---::.            ...
 .====:   .-===========-    ..............
    :-   -===--------====:....           ....
        ===------------=-...               ...
.....  :===-------::::.....                 ...
====-  :==------:.........                   ...
       .===---:...                           ...
        -===-:...                            .....
   :-=:  :=-:...                                ....
  ===:.   ....                                    ...
         ...                                      ...
        ...                                       ...
         ...                                     ....
         ....                                   ....
           .......................................

CURRENT WEATHER:
Current weather for Kansas City in United States of America is Partly cloudy
The temperature is 22,2°C, but feels like 24,6°C

Current Wind Speed: 11,2 kph (E)
Current Air Pressure: 1011,0 mbar
Current Visibility: 14,0 kilometers
Current Precipitation: 0,0 mm
Current Humidity: 71%
Current Cloud Cover: 25%
Current UV Index: 4,0 (Moderate)

FORECAST:
Tomorrow it will be Partly cloudy
Temperature Range: 13,8°C - 26,2°C (average: 19,9°C)
Maximum Wind Speed: 13,7 kph
Average Visibility: 10,0 kilometers
Maximum Precipitation: 0,0 mm
UV Index: 5,0 (Moderate)
Chance of rain/snow: 0% / 0%

AIR QUALITY:
Carbon Monoxide: 337,10 ug/m3
Nitrogen Dioxide: 13,0 ug/m3
Ozone: 37,90 ug/m3
Sulphur Dioxide: 2,30 ug/m3
Fine Particles Matter: 13,10 ug/m3
Coarse Particles Matter: 13,5 ug/m3
US Epa Index: 1 (Good)

Last Update: 2023-06-08 09:00
```
## Contributing

Contributions are always welcome!

See [contributing](https://github.com/pazurkota/console-weather/blob/master/CONTRIBUTING.md) for ways to get started.

Please look also at the [Code Of Conduct](https://github.com/pazurkota/console-weather/blob/master/CODE_OF_CONDUCT.md)


## Acknowledgements

#### Used frameworks:
- [Newtonsoft.Json](https://www.newtonsoft.com/json)
- [RestSharp](https://restsharp.dev)
- [System.CommandLine](https://learn.microsoft.com/en-us/dotnet/standard/commandline/)

#### API and Icons:
- [Weather API](https://www.weatherapi.com/)
- [ASCII Converter](https://ascii-generator.site)


## Lessons Learned

This project basically was created to learn how to work with the API (in this case, weather API) and creating CLI apps using C#
