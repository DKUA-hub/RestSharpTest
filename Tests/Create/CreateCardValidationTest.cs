using NUnit.Framework;
using RestSharp;
using RestSharpTest.Arguments.Holders;
using RestSharpTest.Arguments.Providers;
using RestSharpTest.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Tests.Create
{
    public class CreateCardValidationTest :BaseClass
    {
        [Test]
        [TestCaseSource(typeof(CardNamesProvider))]
        public async Task TestCreateCardWithInvalidParameters(CardNamesHolder cardNames)
        {
            var request = RequestWithAuth(CardsEndpoints.CREATE_CARD, Method.Post)
                .AddJsonBody(cardNames.RequestBody);
            var response = await _client.ExecuteAsync(request);

            string responseContent = response.Content;

            Assert.AreEqual(cardNames.StatusCode, response.StatusCode);
            Assert.AreEqual(cardNames.Message, responseContent);

        }

        [Test]
        [TestCaseSource(typeof(CardAuthArgumentsProvider))]
        public async Task TestCreateCardWithInvalidAuth(AuthArgumentsHolder validationAuth)
        {
            string cardName = "QA Framework new card test";
            var request = RequestWithoutAuth(CardsEndpoints.CREATE_CARD, Method.Post)
                .AddOrUpdateParameters(validationAuth.AuthParams)
                .AddJsonBody(new { name = cardName, idList = UrlParametersValues.LIST_ID });
            var response = await _client.ExecuteAsync(request);

            string responseContent = response.Content;

            Assert.AreEqual(validationAuth.StatusCode, response.StatusCode);
            Assert.AreEqual(validationAuth.Message, responseContent);
        }
    }
}
