# ⛅ Console Weather project
Console Weather project is a simple application project to check weather in console. This project uses the [Weather API](https://www.weatherapi.com/) for best weather forecast




![MIT License](https://img.shields.io/badge/License-MIT-green.svg) 
![Release](https://img.shields.io/github/v/release/pazurkota/console-weather?include_prereleases)
![Repo Size](https://img.shields.io/github/repo-size/pazurkota/console-weather)


## Features

- Show Temperature and Weather Condition
- Show current Wind Speed and Direction
- Show Air Pressure, Humidity and Cloud Cover
- Show Weather Alerts (if exist)



## Installation

#### Requirements:
- [.NET 7.0 or newer](https://dotnet.microsoft.com/en-us/download)
- [Weather API Key](https://www.weatherapi.com)
    
#### Installation:
1. Clone the repository
2. Create `config.json` file in root directory with the following content:
```json
{
  "api-key": "YOUR WEATHER API KEY HERE"
}
```
3. Insert the following Program Arguments: 
`-c "City of choice"` OR `--city "City of choice"`
## Example Output:
```
Weather for London, United Kingdom (last update: 2023-04-11 09:30):

Teperature: 9,0°C (feels like: 6,4°C)
Weather Condition: Partly cloudy
Wind Speed: 16,9kmp (WSW)
Air Pressure: 1013,0 mbar
Humidity: 76%
Cloud Cover: 25%

Weather Alerts:
Yellow wind warning issued by UK Met Office:
A developing area of low pressure running north through the Irish Sea is likely to bring a spell of strong winds, accompanied by 
some heavy rain, to parts of central and western England, Wales, southwest Scotland and the east of Northern Ireland. Gusts of 45-50 
mph are possible inland and perhaps in excess of 60 mph for a time around some Irish Sea coastal areas. For further details see 
https://www.metoffice.gov.uk/weather/warnings-and-advice/uk-warnings
```


## Lessons Learned

This project basicly was created to learn how to work with the API (in this case, weather API) and creating CLI apps using C#


## License and support
This project is under [MIT License](https://choosealicense.com/licenses/mit/)

For any project-related things, please contact me on Discord: pazurkota#1001
