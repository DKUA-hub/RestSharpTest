using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpTest.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Tests.Delete
{
    internal class DeleteCardTest : BaseClass
    {
        private string _cardIdToDelete;

        [SetUp]
        public void CreateCard()
        {
            var request = RequestWithAuth(CardsEndpoints.CREATE_CARD, Method.Post)
                .AddJsonBody(new Dictionary<string, string> { 
                    { "name", "QA Framework: card for deletion" },
                    { "idList", UrlParametersValues.LIST_ID }
                });
            var response = _client.Post(request);
            
            _cardIdToDelete = JToken.Parse(response.Content).SelectToken("id").ToString();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task TestDeleteCard()
        {
            var request = RequestWithAuth(CardsEndpoints.DELETE_CARD, Method.Delete)
                .AddUrlSegment("cardId", _cardIdToDelete);
            var response = await _client.ExecuteAsync(request);
                        
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("{}", JToken.Parse(response.Content).SelectToken("limits").ToString());

            request = RequestWithAuth(CardsEndpoints.GET_ALL_CARDS, Method.Get)
                .AddUrlSegment("listId", UrlParametersValues.LIST_ID);
            response = await _client.ExecuteAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.False(JToken.Parse(response.Content).Any(item => item["id"]?.Value<string>() == _cardIdToDelete));
        }
    }
}
