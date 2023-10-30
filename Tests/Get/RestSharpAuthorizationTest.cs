using RestSharp;
using RestSharpTest.Arguments.Providers;
using RestSharpTest.Arguments.Holders;
using NUnit.Framework;
using RestSharpTest.Constants;

namespace RestSharpTest.Tests.Get
{
    public class RestSharpAuthorizationTest : BaseClass
    {
        [Test]
        [TestCaseSource(typeof(CardIdArgumentsProvider))]
        public async Task TestInvalidCardId(CardIdArgumentsHolder validationArguments)
        {
            var request = RequestWithAuth(CardsEndpoints.GET_CARD, Method.Get)
                .AddOrUpdateParameters(validationArguments.PathParams);
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(validationArguments.StatusCode));
            Assert.That(response.Content, Is.EqualTo(validationArguments.ErrorMessage));
        }

        [Test]
        [TestCaseSource(typeof(CardIdAuthProvider))]
        public async Task TestAccessWithInvalidKey(CardIdAuthHolder validationAuth)
        {
            var request = RequestWithoutAuth(CardsEndpoints.GET_CARD, Method.Get)
                .AddOrUpdateParameters(validationAuth.PathParams)
                .AddQueryParameter("key", validationAuth.Key)
                .AddQueryParameter("token", validationAuth.Token);
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(validationAuth.StatusCode));
            Assert.That(response.Content, Is.EqualTo(validationAuth.ErrorMessage));
        }

        [Test]
        [TestCaseSource(typeof(AuthArgumentsProvider))]
        public async Task TestAuthProcess(AuthArgumentsHolder validationAuth)
        {
            var request = RequestWithoutAuth(CardsEndpoints.GET_CARD, Method.Get)
                .AddOrUpdateParameters(validationAuth.AuthParams)
                .AddOrUpdateParameters(validationAuth.PathParameter);
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(validationAuth.StatusCode));
            Assert.That(response.Content, Is.EqualTo(validationAuth.Message));
        }
    }
}
