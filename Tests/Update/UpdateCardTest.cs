using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpTest.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Tests.Update
{
    internal class UpdateCardTest : BaseClass
    {
        [Test]
        public async Task TestUpdateCardName()
        {
            string updatedCardName = "qa framework updated name" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var request = RequestWithAuth(CardsEndpoints.UPDATE_CARD, Method.Put)
                .AddUrlSegment("cardId", UrlParametersValues.CARD_ID_TO_UPDATE)
                .AddJsonBody(new { name = updatedCardName });

            var response = await _client.ExecuteAsync(request);

            var responseContent = response.Content;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(updatedCardName, JToken.Parse(responseContent).SelectToken("name").ToString());

            request = RequestWithAuth(CardsEndpoints.GET_CARD, Method.Get)
                .AddUrlSegment("cardId", UrlParametersValues.CARD_ID_TO_UPDATE);
            response = await _client.ExecuteAsync(request);

            var responseJson = JToken.Parse(response.Content);
            Assert.AreEqual(updatedCardName, responseJson.SelectToken("name").ToString());
        }
    }
}
