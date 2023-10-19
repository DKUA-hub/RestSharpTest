using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;
using System.Net;

namespace RestSharpTest
{
    public class RestSharpTest : BaseClass
    {
        [Test]
        public void CheckCardsReturnCode() 
        {
            var request = RequestWithAuth("1/lists/{listId}/cards")
                .AddQueryParameter("fields","id,name")
                .AddUrlSegment("listId", "65134c3fc8a1a9c5e1c48d59");
            IRestResponse response = _client.Get(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schema/get_cards.json"));
            Assert.IsTrue(responseContent.IsValid(jsonSchema));
        }

        [Test]
        public void CheckCardsName() 
        {
            var request = RequestWithAuth("1/cards/{cardId}")
                .AddQueryParameter("fields", "idBoard,idChecklists,idLabels,idList,idMembers,idShort,idAttachmentCover,name")
                .AddUrlSegment("cardId", "65134c5117c9d3b7f9d2250f");
            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JToken.Parse(response.Content).SelectToken("name").ToString(), Is.EqualTo("API docs"));
            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schema/get_card.json"));
            Assert.IsTrue(responseContent.IsValid(jsonSchema));
        }
    }
}
