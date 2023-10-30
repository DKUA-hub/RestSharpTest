using NUnit.Framework;
using RestSharp;
using RestSharpTest.Constants;

namespace RestSharpTest.Tests
{
    public class BaseClass
    {
        protected static IRestClient _client;

        [OneTimeSetUp]
        public static void InitializeRestClient() =>
            _client = new RestClient(UrlParametersValues.URL);

        protected static RestRequest RequestWithAuth(string endpoint, Method method) =>
            RequestWithoutAuth(endpoint, method)
                .AddOrUpdateParameters(UrlParametersValues.AUTH_CREDENTIALS);

        protected static RestRequest RequestWithoutAuth(string endpoint, Method method) =>
            new RestRequest(endpoint, method);
    }
}
