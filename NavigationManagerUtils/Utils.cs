using System;
using System.Linq;

namespace NavigationManagerUtils
{
    internal static class Utils
    {
        internal static Dictionary<string, string> ParseUrlParameters(bool RemoveWhitespaceEntityInValue, bool RemoveWhitespaceEntityInKey, Dictionary<string, string> Parameters, string Url)
        {
            Dictionary<string, string> ParametersClone = Parameters;
            string UrlArguments = Url.Split('?')[1];

            if (Url.Contains('&'))
            {
                MultipleParametersParse(RemoveWhitespaceEntityInKey, ParametersClone, UrlArguments);
            }
            else
            {
                SingleParameterParse(RemoveWhitespaceEntityInKey, ParametersClone, UrlArguments);
            }

            if (RemoveWhitespaceEntityInValue)
            {
                foreach (KeyValuePair<string, string> para in ParametersClone)
                {
                    ParametersClone[para.Key] = para.Value.Replace("%20", " ");
                }
            }
            return ParametersClone;
        }

        private static void SingleParameterParse(bool RemoveWhitespaceEntityInKey, Dictionary<string, string> ParametersClone, string UrlArguments)
        {
            string[] SingleArgument = UrlArguments.Split('=');
            if (RemoveWhitespaceEntityInKey)
            {
                ParametersClone.Add(SingleArgument[0].Replace("%20", " "), SingleArgument[1]);
            }
            else
            {
                ParametersClone.Add(SingleArgument[0], SingleArgument[1]);
            }
        }

        private static void MultipleParametersParse(bool RemoveWhitespaceEntityInKey, Dictionary<string, string> ParametersClone, string UrlArguments)
        {
            string[] ArgumentGroups = UrlArguments.Split('&');
            foreach (string arggroup in ArgumentGroups)
            {
                string[] SingleArgument = arggroup.Split('=');
                if (RemoveWhitespaceEntityInKey)
                {
                    ParametersClone.Add(SingleArgument[0].Replace("%20", " "), SingleArgument[1]);
                }
                else
                {
                    ParametersClone.Add(SingleArgument[0], SingleArgument[1]);
                }
            }
        }
    }
}
