using System.Collections;
using System.Net;
using RestSharpTest.Arguments.Holders;
using RestSharp;
using RestSharpTest.Constants;

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
                    PathParams = new[] {new Parameter("cardId", UrlParametersValues.CARD_ID, ParameterType.UrlSegment)},
                    Key = UrlParametersValues.INVALID_KEY,
                    Token = UrlParametersValues.INVALID_TOKEN
                }
            };

            yield return new object[]
            {
                new CardIdAuthHolder
                {
                    ErrorMessage = "invalid token",
                    StatusCode = HttpStatusCode.Unauthorized,
                    PathParams = new[] {new Parameter("cardId", UrlParametersValues.CARD_ID, ParameterType.UrlSegment)},
                    Key = UrlParametersValues.INVALID_KEY,
                    Token = Environment.GetEnvironmentVariable("TRELLO_TOKEN")
                }
            };

            yield return new object[]
            {
                new CardIdAuthHolder
                {
                    ErrorMessage = "invalid key",
                    StatusCode = HttpStatusCode.Unauthorized,
                    PathParams = new[] {new Parameter("cardId", UrlParametersValues.CARD_ID, ParameterType.UrlSegment)},
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
                    PathParams = new[] {new Parameter("cardId", UrlParametersValues.CARD_ID, ParameterType.UrlSegment)},
                    Key = "fb04999a731923c2e3137153b1ad5de0",
                    Token = "b73120fb537fceb444050a2a4c08e2f96f47389931bd80253d2440708f2a57e1"
                }
            };
        }
    }
}
