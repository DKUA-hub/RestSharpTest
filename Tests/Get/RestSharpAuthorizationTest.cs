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
        public void TestInvalidCardId(CardIdArgumentsHolder validationArguments)
        {
            var request = RequestWithAuth(CardsEndpoints.GET_CARD)
                .AddOrUpdateParameters(validationArguments.PathParams);
            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(validationArguments.StatusCode));
            Assert.That(response.Content, Is.EqualTo(validationArguments.ErrorMessage));
        }

        [Test]
        [TestCaseSource(typeof(CardIdAuthProvider))]
        public void TestAccessWithInvalidKey(CardIdAuthHolder validationAuth)
        {
            var request = RequestWithoutAuth(CardsEndpoints.GET_CARD)
                .AddOrUpdateParameters(validationAuth.PathParams)
                .AddQueryParameter("key", validationAuth.Key)
                .AddQueryParameter("token", validationAuth.Token);
            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(validationAuth.StatusCode));
            Assert.That(response.Content, Is.EqualTo(validationAuth.ErrorMessage));
        }

        [Test]
        [TestCaseSource(typeof(AuthArgumentsProvider))]
        public void TestAuthProcess(AuthArgumentsHolder validationAuth)
        {
            var request = RequestWithoutAuth(CardsEndpoints.GET_CARD)
                .AddOrUpdateParameters(validationAuth.AuthParams)
                .AddOrUpdateParameters(validationAuth.PathParameter);
            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(validationAuth.StatusCode));
            Assert.That(response.Content, Is.EqualTo(validationAuth.Message));
        }
    }
}
