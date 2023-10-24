using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using RestSharpTest.Constants;
using System.Net;

namespace RestSharpTest.Tests.Get
{
    public class RestSharpTest : BaseClass
    {
        [Test]
        public void CheckCardsReturnCode()
        {
            var request = RequestWithAuth(CardsEndpoints.GET_ALL_CARDS)
                .AddQueryParameter("fields", "id,name")
                .AddUrlSegment("listId", UrlParametersValues.LIST_ID);
            IRestResponse response = _client.Get(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schema/get_cards.json"));
            Assert.IsTrue(responseContent.IsValid(jsonSchema));
        }

        [Test]
        public void CheckCardsName()
        {
            var request = RequestWithAuth(CardsEndpoints.GET_CARD)
                .AddQueryParameter("fields", "idBoard,idChecklists,idLabels,idList,idMembers,idShort,idAttachmentCover,name")
                .AddUrlSegment("cardId", UrlParametersValues.CARD_ID);
            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JToken.Parse(response.Content).SelectToken("name").ToString(), Is.EqualTo("API docs"));
            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schema/get_card.json"));
            Assert.IsTrue(responseContent.IsValid(jsonSchema));
        }
    }
}
