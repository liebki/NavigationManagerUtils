namespace NavigationManagerUtils
{
    internal static class Utils
    {
        private const string WhitespaceEncoding = "%20";

        internal static Dictionary<string, string> ParseUrlParameters(bool removeWhitespaceEntityInValue, bool removeWhitespaceEntityInKey, Dictionary<string, string> parameters, string url)
        {
            string urlArguments = url.Split('?')[1];
            if (url.Contains('&'))
            {
                MultipleParametersParse(removeWhitespaceEntityInKey, parameters, urlArguments);
            }
            else
            {
                SingleParameterParse(removeWhitespaceEntityInKey, parameters, urlArguments);
            }

            if (!removeWhitespaceEntityInValue)
                return parameters;
            
            foreach (KeyValuePair<string, string> para in parameters)
            {
                parameters[para.Key] = para.Value.Replace(WhitespaceEncoding, " ");
            }
            
            return parameters;
        }

        private static void SingleParameterParse(bool removeWhitespaceEntityInKey, Dictionary<string, string> parametersTemp, string urlArguments)
        {
            string[] singleArgument = urlArguments.Split('=');
            parametersTemp.Add(removeWhitespaceEntityInKey ? singleArgument[0].Replace(WhitespaceEncoding, " ") : singleArgument[0], singleArgument[1]);
        }

        private static void MultipleParametersParse(bool removeWhitespaceEntityInKey, Dictionary<string, string> parametersClone, string urlArguments)
        {
            string[] argumentGroups = urlArguments.Split('&');
            foreach (string argGroup in argumentGroups)
            {
                string[] singleArgument = argGroup.Split('=');
                parametersClone.Add(removeWhitespaceEntityInKey ? singleArgument[0].Replace(WhitespaceEncoding, " ") : singleArgument[0], singleArgument[1]);
            }
        }
    }
}
