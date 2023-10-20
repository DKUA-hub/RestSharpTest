using System.Collections;
using System.Net;
using RestSharpTest.Arguments.Holders;
using RestSharp;


namespace RestSharpTest.Arguments.Providers
{
    public class CardIdAuthProvider: IEnumerable
    {
        public IEnumerator GetEnumerator() 
        {
            yield return new object[]
            {
                new CardIdAuthHolder
                {
                    ErrorMessage = "invalid token",
                    StatusCode = HttpStatusCode.Unauthorized,
                    PathParams = new[] {new Parameter("cardId", "65134c5117c9d3b7f9d2250f", ParameterType.UrlSegment)},
                    Key = "eb98438106f7eb8308aa3cb9d166457b",
                    Token = "ATTAa74ad9c95079a0cb446a636c3e31fe3f62839f45a0976cb5bd8ce790cf7f46c5A03EDC4E"
                }
            };

            yield return new object[]
            {
                new CardIdAuthHolder
                {
                    ErrorMessage = "invalid token",
                    StatusCode = HttpStatusCode.Unauthorized,
                    PathParams = new[] {new Parameter("cardId", "65134c5117c9d3b7f9d2250f", ParameterType.UrlSegment)},
                    Key = "eb98438106f7eb8308aa3cb9d166457b",
                    Token = Environment.GetEnvironmentVariable("TRELLO_TOKEN")
                }
            };

            yield return new object[]
            {
                new CardIdAuthHolder
                {
                    ErrorMessage = "invalid key",
                    StatusCode = HttpStatusCode.Unauthorized,
                    PathParams = new[] {new Parameter("cardId", "65134c5117c9d3b7f9d2250f", ParameterType.UrlSegment)},
                    Key = "eb98438106f7eb8308aa3cb9d166457",
                    Token = Environment.GetEnvironmentVariable("TRELLO_TOKEN")
                }
            };

            yield return new object[]
            {
                new CardIdAuthHolder
                {
                    ErrorMessage = "unauthorized card permission requested",
                    StatusCode = HttpStatusCode.Unauthorized,
                    PathParams = new[] {new Parameter("cardId", "65134c5117c9d3b7f9d2250f", ParameterType.UrlSegment)},
                    Key = "fb04999a731923c2e3137153b1ad5de0",
                    Token = "b73120fb537fceb444050a2a4c08e2f96f47389931bd80253d2440708f2a57e1"
                }
            };
        }
    }
}
