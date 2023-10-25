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
        public void TestCreateCardWithInvalidParameters(CardNamesHolder cardNames)
        {
            var request = RequestWithAuth(CardsEndpoints.CREATE_CARD)
                .AddJsonBody(cardNames.RequestBody);
            var response = _client.Post(request);

            string responseContent = response.Content;

            Assert.AreEqual(cardNames.StatusCode, response.StatusCode);
            Assert.AreEqual(cardNames.Message, responseContent);

        }

        [Test]
        [TestCaseSource(typeof(CardAuthArgumentsProvider))]
        public void TestCreateCardWithInvalidAuth(AuthArgumentsHolder validationAuth)
        {
            string cardName = "QA Framework new card test";
            var request = RequestWithoutAuth(CardsEndpoints.CREATE_CARD)
                .AddOrUpdateParameters(validationAuth.AuthParams)
                .AddJsonBody(new { name = cardName, idList = UrlParametersValues.LIST_ID });
            var response = _client.Post(request);


            string responseContent = response.Content;

            Assert.AreEqual(validationAuth.StatusCode, response.StatusCode);
            Assert.AreEqual(validationAuth.Message, responseContent);
        }
    }
}
