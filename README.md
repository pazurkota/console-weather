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
dotnet tool install --global console-weather --version 1.3.0
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

To use specific units, type:
```bash
weather -u Si # Example
```

Full command list:
```bash
  -c, --city <city>          Get city name
  --no-alerts                Hide weather alerts [default: False]
  -f, --forecast             Show weather forecast [default: False]
  -u, --units <Eu|Si|Uk|Us>  Set weather units
  --version                  Show version information
  -?, -h, --help             Show help and usage information
```


## Demo

Example input:
``` 
weather -c "Kansas City" -f -u Si
```

Example output:
```
Current weather for Kansas City in United States of America is Mist
The temperature is 17,2°C, but feels like 17,2°C

Current Wind Speed is 3,1 m/s ESE
Current Air Pressure is 1009,0 mbar
Current Humidity is 93%
Current Cloud Cover is 100%
Last Update: 2023-05-06 06:45

Tomorrow it will be Partly cloudy
The temperature range will be around 14,8°C to 32,7°C, with average of 23,1°C
The maximum wind speed will be around 8,1 m/s
The chance of rain/snow: 0% / 0%
```
## Acknowledgements

- [NuGet Page](https://www.nuget.org/packages/console-weather/)


## License and support
This project is under [MIT License](https://github.com/pazurkota/console-weather/blob/master/LICENCE.md)

For any project-related cases, please contact me on Discord: pazurkota#1001


## Lessons Learned

This project basically was created to learn how to work with the API (in this case, weather API) and creating CLI apps using C#




