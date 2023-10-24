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

        protected static IRestRequest RequestWithAuth(string endpoint) =>
            RequestWithoutAuth(endpoint)
                .AddOrUpdateParameters(UrlParametersValues.AUTH_CREDENTIALS);

        protected static IRestRequest RequestWithoutAuth(string endpoint) =>
            new RestRequest(endpoint);
    }
}
