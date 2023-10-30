using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpTest.Constants;
using System.Net;

namespace RestSharpTest.Tests.Create
{
    internal class CreateCardTest : BaseClass
    {
        private string _createdCardId;
        [Test]
        public async Task TestCreateBoardAsync()
        {
            string cardName = "NewBoard" + DateTime.Now.ToLongTimeString();
            var request = RequestWithAuth(CardsEndpoints.CREATE_CARD, Method.Post)
                .AddJsonBody(new {name=cardName, idList=UrlParametersValues.LIST_ID});
            var response = await _client.ExecuteAsync(request);

            var responseContent = JToken.Parse(response.Content);
            _createdCardId = responseContent.SelectToken("id").ToString();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(cardName, responseContent.SelectToken("name").ToString());

            request = RequestWithAuth(CardsEndpoints.GET_ALL_CARDS, Method.Get)
                .AddUrlSegment("listId", UrlParametersValues.LIST_ID);
            response = await _client.ExecuteAsync(request);

            responseContent = JToken.Parse(response.Content);
            Assert.True(responseContent.Children().Select(token => token.SelectToken("name").ToString()).Contains(cardName));
        }

        [TearDown]
        public async Task DeleteCreatedCard()
        {
            var request = RequestWithAuth(CardsEndpoints.DELETE_CARD, Method.Delete)
                .AddUrlSegment("cardId", _createdCardId);
            var response = await _client.ExecuteAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            request = RequestWithAuth(CardsEndpoints.GET_ALL_CARDS, Method.Get)
                .AddUrlSegment("listId", UrlParametersValues.LIST_ID);
            response = await _client.ExecuteAsync(request);

            var responseContent = JToken.Parse(response.Content);
            Assert.False(responseContent.Children().Select(token => token.SelectToken("id").ToString()).Contains(_createdCardId));
        }
    }
}
