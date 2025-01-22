# NavigationManagerUtils

## Overview

**NavigationManagerUtils** is a very simple injectable service, created to enhance the capabilities of the `NavigationManager` in Blazor applications. It provides additional utility methods that simplify navigation and URL parameter management.

---

## Technologies Used

- **.NET Core 8.0**

---

## Features

### What is NavigationManagerUtils?

This is an injectable service for Blazor applications that builds upon the standard `NavigationManager`, adding commonly-used features for navigation and URL management.

### Example Usage

To see this utility in action, refer to the `NavManUtilTest` project—a simple Blazor Server application that demonstrates its functionality.

---

## Getting Started

### Installation

Add the service to your application during configuration:

```csharp
builder.Services.AddTransient<NavManUtils>();
```

### Injecting the Service

1. **In Code**  
   Use the `[Inject]` attribute:

   `[Inject] private NavManUtils NavMan { get; set; }`

2. **In Razor Components**  
   Use the `@inject` directive:

   `@inject NavManUtils NavMan`

---

## Available Methods

1. **`Navigate(string url, bool force = true)`**  
   Navigate to the specified URL. The `force` parameter determines whether to reload the page even if already on the target URL.

2. **`[DEPRECATED] Reload(bool force = true)`**  
   Reload the current page. The `force` parameter determines whether to reload from the server.

3. **`UrlHasParameters()`**  
   Returns `true` if the current URL contains query parameters, otherwise `false`.

4. **`GetUrlParameters(bool removeWhitespaceEntityInValue = false, bool removeWhitespaceEntityInKey = false)`**  
   Retrieves the query parameters from the current URL as a `Dictionary<string, string>`.
	- `removeWhitespaceEntityInValue`: Strips %20 whitespace entities from parameter values.
	- `removeWhitespaceEntityInKey`: Strips %20 whitespace entities from parameter keys.

5. **`GetNavMan()`**  
   Provides access to the underlying `NavigationManager` instance without requiring separate injection.

---

## License

This project is licensed under the **GNU General Public License v3.0**. For more details, visit [GNU License](https://choosealicense.com/licenses/gpl-3.0/).

--- 