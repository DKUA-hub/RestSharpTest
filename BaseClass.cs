using RestSharp;

namespace RestSharpTest
{
    public class BaseClass
    {
        protected static IRestClient _client;

        [OneTimeSetUp]
        public static void InitializeRestClient() =>
            _client = new RestClient("https://api.trello.com/");

        protected static IRestRequest RequestWithAuth(String endpoint) =>
            RequestWithoutAuth(endpoint)
                .AddQueryParameter("key", System.Environment.GetEnvironmentVariable("TRELLO_AUTH_KEY"))
                .AddQueryParameter("token", System.Environment.GetEnvironmentVariable("TRELLO_TOKEN"));

        protected static IRestRequest RequestWithoutAuth(String endpoint) =>
            new RestRequest(endpoint);

    }
}
