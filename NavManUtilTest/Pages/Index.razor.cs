
using NavigationManagerUtils;

using Microsoft.AspNetCore.Components;

namespace NavManUtilTest.Pages
{
    partial class Index
    {
        [Inject]
        private NavManUtils NavMan { get; set; }

        private Dictionary<string, string> ParametersList { get; set; } = new();

        private string FreeformParametesTextinput { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (NavMan.UrlHasParameters())
            {
                ParametersList = NavMan.GetUrlParameters(true, true);
            }
        }

        private async Task NavigateTestNoArgument()
        {
            NavMan.Navigate("/");
        }

        private async Task NavigateTestSingle()
        {
            NavMan.Navigate("/?abc=1");
        }

        private async Task NavigateTestMultiple()
        {
            NavMan.Navigate("/?abc=1&xyz=2&bbb=3");
        }

        private async Task NavigateCustomParameter()
        {
            if (!string.IsNullOrEmpty(FreeformParametesTextinput) && FreeformParametesTextinput.Length >= 3 && FreeformParametesTextinput.Contains('?'))
            {
                NavMan.Navigate(FreeformParametesTextinput);
            }
            else
            {
                NavMan.Navigate("/?you=You_need&made=to_define&a=parameters&mistake=like_in_the_example");
            }
        }
    }
}