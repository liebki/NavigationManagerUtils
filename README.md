# NavigationManagerUtils

## Technologies

### Created using
-.NET Core 6.0

## Features

### What is this?
- A simple service, injectable in a blazor application, to enhance the NavigationManager by a couple of things I often use and find useful.

### Example?
- The 'NavManUtilTest' project, is a simplpe example blazor-server application

### General

#### Usage
- Add the service to WebApplicationBuilder or MauiBuilder using 
```builder.Services.AddTransient<NavManUtils>();```
- To use it, inject it like this in code:
```
[Inject]
private NavManUtils NavMan { get; set; }
```
or in a razor component like this:
```
@inject NavManUtils NavMan
```

#### Current functionality
- Navigate(string url, bool force = true)
	- Navigate to a new URL
- Reload(bool force = true)
	- Reload the page
- UrlHasParameters()
	- Get a bool back, to find out find out if the current URL contains parameters to extract
- GetUrlParameters(bool RemoveWhitespaceEntityInValue = false, bool RemoveWhitespaceEntityInKey = false)
	- Get a Dictionary<string, string> with the parameter-keys as keys and the parameter-values as values
- GetNavigationManager()
	- Access the NavigationManager, without the need of injecting it seperatly

## License

**Software:** NavigationManagerUtils

**License:** GNU General Public License v3.0

**Licensor:** Kim Mario Liebl

[GNU](https://choosealicense.com/licenses/gpl-3.0/)