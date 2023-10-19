using RestSharp;
using System.Net;

namespace RestSharpTest
{
    public class RestSharpAuthorizationTest : BaseClass
    {
        [Test]
        public void CheckInvalidCardId() 
        {
            var request = RequestWithAuth("1/cards/{cardId}")
                .AddUrlSegment("cardId", "65134c5117c9d3b7f9d22507");
            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(response.Content, Is.EqualTo("The requested resource was not found."));
        }

        [Test]
        public void CheckAccessWithInvalidKey()
        {
            var request = RequestWithoutAuth("1/cards/{cardId}")
                .AddUrlSegment("cardId", "65134c5117c9d3b7f9d2250f")
                .AddQueryParameter("key", "eb98438106f7eb8308aa3cb9d166457")
                .AddQueryParameter("token", "ATTAa74ad9c95079a0cb446a636c3e31fe3f62839f45a0976cb5bd8ce790cf7f46c5A03EDC4E");
            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Content, Is.EqualTo("invalid key"));
        }

        [Test]
        public void CheckAccessWithInvalidToken()
        {
            var request = RequestWithoutAuth("1/cards/{cardId}")
                .AddUrlSegment("cardId", "65134c5117c9d3b7f9d2250f")
                .AddQueryParameter("key", "eb98438106f7eb8308aa3cb9d166457b")
                .AddQueryParameter("token", "TTAa74ad9c95079a0cb446a636c3e31fe3f62839f45a0976cb5bd8ce790cf7f46c5A03EDC4E");
            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Content, Is.EqualTo("invalid token"));
        }

        [Test]
        public void CheckAccessWithWrongCredentials()
        {
            var request = RequestWithoutAuth("1/cards/{cardId}")
                .AddUrlSegment("cardId", "65134c5117c9d3b7f9d2250f")
                .AddQueryParameter("key", "fb04999a731923c2e3137153b1ad5de0")
                .AddQueryParameter("token", "b73120fb537fceb444050a2a4c08e2f96f47389931bd80253d2440708f2a57e1");
            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Content, Is.EqualTo("unauthorized card permission requested"));
        }
    }
}
