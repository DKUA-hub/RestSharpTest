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
                .AddQueryParameter("key", "eb98438106f7eb8308aa3cb9d166457b")
                .AddQueryParameter("token", "ATTAa74ad9c95079a0cb446a636c3e31fe3f62839f45a0976cb5bd8ce790cf7f46c5A03EDC4E");

        protected static IRestRequest RequestWithoutAuth(String endpoint) =>
            new RestRequest(endpoint);

    }
}
