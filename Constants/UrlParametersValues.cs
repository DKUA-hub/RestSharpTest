using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RestSharpTest.Constants
{
    internal class UrlParametersValues
    {
        public const string URL     = "https://api.trello.com/";
        public const string LIST_ID = "65134c3fc8a1a9c5e1c48d59";
        public const string CARD_ID = "65134c5117c9d3b7f9d2250f";
        
        public const string CARD_ID_TO_UPDATE    = "6515a0b118eaee89ad91ae9b";
        public const string INVALID_CARD_ID      = "65134c5117c9d3b7f9d2250";
        public const string ANOTHER_USER_CARD_ID = "60e03f7ff7c9234efd7ed41f";
        public const string ANOTHER_USER_LIST_ID = "60d84769c4ce7a09f9140221";

        public static string VALID_KEY   = Environment.GetEnvironmentVariable("TRELLO_AUTH_KEY");
        public static string VALID_TOKEN = Environment.GetEnvironmentVariable("TRELLO_TOKEN");

        public static string INVALID_KEY   = "eb98438106f7eb8308aa3cb9d166457b";
        public static string INVALID_TOKEN = "ATTAa74ad9c95079a0cb446a636c3e31fe3f62839f45a0976cb5bd8ce790cf7f46c5A03EDC4E";


        public static IEnumerable<Parameter> AUTH_CREDENTIALS = new[]
        {
            new Parameter ("key",   VALID_KEY, ParameterType.QueryString),
            new Parameter ("token", VALID_TOKEN, ParameterType.QueryString)
        };

        public static IEnumerable<Parameter> INVALID_AUTH_CREDENTIALS = new[]
        {
            new Parameter ("key",   INVALID_KEY, ParameterType.QueryString),
            new Parameter ("token", INVALID_TOKEN, ParameterType.QueryString)
        };

        public static IEnumerable<Parameter> ANOTHER_USER_AUTH_CREDENTIALS = new[]
        {
            new Parameter ("key",   "fb04999a731923c2e3137153b1ad5de0", ParameterType.QueryString),
            new Parameter ("token", "b73120fb537fceb444050a2a4c08e2f96f47389931bd80253d2440708f2a57e1", ParameterType.QueryString)
        };
    }
}
