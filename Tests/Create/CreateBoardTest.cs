using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpTest.Constants;
using System.Net;

namespace RestSharpTest.Tests.Create
{
    internal class CreateBoardTest : BaseClass
    {
        private string _createdCardId;
        [Test]
        public void TestCreateBoard()
        {
            string cardName = "NewBoard" + DateTime.Now.ToLongTimeString();
            var request = RequestWithAuth(CardsEndpoints.CREATE_CARD)
                .AddJsonBody(new {name=cardName, idList=UrlParametersValues.LIST_ID});
            var response = _client.Post(request);

            var responseContent = JToken.Parse(response.Content);
            _createdCardId = responseContent.SelectToken("id").ToString();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(cardName, responseContent.SelectToken("name").ToString());

            request = RequestWithAuth(CardsEndpoints.GET_ALL_CARDS)
                .AddUrlSegment("listId", UrlParametersValues.LIST_ID);
            response = _client.Get(request);

            responseContent = JToken.Parse(response.Content);
            Assert.True(responseContent.Children().Select(token => token.SelectToken("name").ToString()).Contains(cardName));
        }

        [TearDown]
        public void DeleteCreatedCard()
        {
            var request = RequestWithAuth(CardsEndpoints.DELETE_CARD)
                .AddUrlSegment("cardId", _createdCardId);
            var response = _client.Delete(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            request = RequestWithAuth(CardsEndpoints.GET_ALL_CARDS)
                .AddUrlSegment("listId", UrlParametersValues.LIST_ID);
            response = _client.Get(request);

            var responseContent = JToken.Parse(response.Content);
            Assert.False(responseContent.Children().Select(token => token.SelectToken("id").ToString()).Contains(_createdCardId));
        }
    }
}
