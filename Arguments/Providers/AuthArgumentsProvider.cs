using RestSharp;
using RestSharpTest.Arguments.Holders;
using RestSharpTest.Constants;
using System.Collections;
using System.Net;

namespace RestSharpTest.Arguments.Providers
{
    internal class AuthArgumentsProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new AuthArgumentsHolder
                {
                    AuthParams = ArraySegment<Parameter>.Empty,
                    PathParameter = new [] { new Parameter("cardId", UrlParametersValues.CARD_ID, ParameterType.UrlSegment) },
                    StatusCode = HttpStatusCode.Unauthorized,
                    Message = "unauthorized card permission requested"

                }
            };

            yield return new object[]
            {
                new AuthArgumentsHolder
                {
                    AuthParams = new []{ new Parameter("key", UrlParametersValues.VALID_KEY, ParameterType.QueryString)},
                    PathParameter = new[] {new Parameter("cardId", UrlParametersValues.CARD_ID, ParameterType.UrlSegment)},
                    StatusCode = HttpStatusCode.Unauthorized,
                    Message = "unauthorized card permission requested"
                }
            };

            yield return new object[]
            {
                new AuthArgumentsHolder
                {
                    AuthParams = new []{ new Parameter("token", UrlParametersValues.VALID_TOKEN, ParameterType.QueryString)},
                    PathParameter = new[] {new Parameter("cardId", UrlParametersValues.CARD_ID, ParameterType.UrlSegment)},
                    StatusCode = HttpStatusCode.Unauthorized,
                    Message = "invalid key"
                }
            };

            yield return new object[]
            {
                new AuthArgumentsHolder
                {
                    AuthParams = UrlParametersValues.INVALID_AUTH_CREDENTIALS,
                    PathParameter = new[] {new Parameter("cardId", UrlParametersValues.CARD_ID, ParameterType.UrlSegment)},
                    StatusCode = HttpStatusCode.Unauthorized,
                    Message = "invalid token"
                }
            };
        }

    }
}
