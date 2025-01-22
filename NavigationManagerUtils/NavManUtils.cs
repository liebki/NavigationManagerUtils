using Microsoft.AspNetCore.Components;

namespace NavigationManagerUtils
{
    /// <summary>
    /// Provides utility methods for interacting with the NavigationManager in Blazor applications,
    /// including page navigation, parameter extraction, and more.
    /// </summary>
    public class NavManUtils(NavigationManager navigationManager)
    {
        private NavigationManager NavigationManagerInstance { get; } = navigationManager;

        /// <summary>
        /// Reloads the current page.
        /// </summary>
        /// <param name="force">
        /// Indicates whether to force the page reload. Defaults to <c>true</c>.
        /// </param>
        [Obsolete("Please use GetNavMan.Refresh() instead, since it is included now by default.")]
        public void Reload(bool force = true)
        {
            Navigate(NavigationManagerInstance.Uri, force);
        }

        /// <summary>
        /// Navigates to the specified URL.
        /// </summary>
        /// <param name="url">The URL to navigate to</param>
        /// <param name="force">
        /// Indicates whether to force the navigation, bypassing caching. Defaults to <c>true</c>.
        /// </param>
        public void Navigate(string url, bool force = true)
        {
            NavigationManagerInstance.NavigateTo(url, force);
        }

        /// <summary>
        /// Checks whether the current URL contains query parameters.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the URL contains query parameters; otherwise, <c>false</c>.
        /// </returns>
        public bool UrlHasParameters()
        {
            string url = NavigationManagerInstance.Uri;
            return url.Contains('?') && url.Contains('=') || (url.Contains('?') && url.Contains('&') && url.Contains('='));
        }

        /// <summary>
        /// Extracts all query parameters from the current URL into a dictionary.
        /// </summary>
        /// <param name="removeWhitespaceEntityInValue">
        /// If <c>true</c>, replaces <c>%20</c> in parameter values with actual whitespace characters.
        /// </param>
        /// <param name="removeWhitespaceEntityInKey">
        /// If <c>true</c>, replaces <c>%20</c> in parameter keys with actual whitespace characters.
        /// </param>
        /// <returns>
        /// A dictionary containing the query parameters as key-value pairs. 
        /// Returns an empty dictionary if the URL contains no parameters.
        /// </returns>
        public Dictionary<string, string> GetUrlParameters(bool removeWhitespaceEntityInValue = false, bool removeWhitespaceEntityInKey = false)
        {
            Dictionary<string, string> parameters = new();
            string url = NavigationManagerInstance.Uri;

            return url.Contains('?') ? Utils.ParseUrlParameters(removeWhitespaceEntityInValue, removeWhitespaceEntityInKey, parameters, url) : new Dictionary<string, string>();
        }

        /// <summary>
        /// Retrieves the active <see cref="NavigationManager"/> instance used internally.
        /// </summary>
        /// <returns>
        /// The active <see cref="NavigationManager"/> instance.
        /// </returns>
        public NavigationManager GetNavMan()
        {
            return NavigationManagerInstance;
        }
    }
}