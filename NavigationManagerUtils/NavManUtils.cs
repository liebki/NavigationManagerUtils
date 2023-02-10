using Microsoft.AspNetCore.Components;

namespace NavigationManagerUtils
{
    public class NavManUtils
    {
        protected NavigationManager NavMan { get; }

        public NavManUtils(NavigationManager navigationManager)
        {
            NavMan = navigationManager;
        }

        public void Reload(bool force = true)
        {
            NavMan.NavigateTo(NavMan.Uri, force);
        }

        public void Navigate(string url, bool force = true)
        {
            NavMan.NavigateTo(url, force);
        }

        public bool UrlHasParameters()
        {
            string Url = NavMan.Uri.ToString();
            if (Url.Contains('?') && Url.Contains('=') || (Url.Contains('?') && Url.Contains('&') && Url.Contains('=')))
            {
                return true;
            }
            return false;
        }

        public Dictionary<string, string> GetUrlParameters(bool RemoveWhitespaceEntityInValue = false, bool RemoveWhitespaceEntityInKey = false)
        {
            Dictionary<string, string> Parameters = new();
            string Url = NavMan.Uri.ToString();

            if (Url.Contains('?'))
            {
                return Utils.ParseUrlParameters(RemoveWhitespaceEntityInValue, RemoveWhitespaceEntityInKey, Parameters, Url);
            }
            else
            {
                return new();
            }
        }

        public NavigationManager GetNavigationManager()
        {
            return NavMan;
        }
    }
}