using Newtonsoft.Json.Linq;
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

namespace RestSharpTest.Tests.Update
{
    internal class UpdateCardValiationTest : BaseClass
    {
        [Test]
        [TestCaseSource(typeof(CardIdPutArgumentsProvider))]
        public async Task TestUpdateCardInvalidParametersAsync(CardIdPutArgumentsHolder updateArguments)
        {
            var request = RequestWithAuth(CardsEndpoints.UPDATE_CARD, Method.Put)
                .AddOrUpdateParameters(updateArguments.PathParam)
                .AddJsonBody(updateArguments.Body);

            var response = await _client.ExecuteAsync(request);

            Assert.AreEqual(updateArguments.StatusCode, response.StatusCode);
            Assert.AreEqual(updateArguments.Message, response.Content);

        }

        [Test]
        [TestCaseSource(typeof(CardAuthArgumentsProvider))]
        public async Task TestUpdateCardInvalidAuthAsync(AuthArgumentsHolder validationAuth)
        {
            var request = RequestWithoutAuth(CardsEndpoints.UPDATE_CARD, Method.Put)
                .AddOrUpdateParameters(validationAuth.AuthParams)
                .AddOrUpdateParameters(validationAuth.PathParameter)
                .AddJsonBody(new 
                { 
                    name = "QA Framework: updated card name"
                });
            var response = await _client.ExecuteAsync(request);


            string responseContent = response.Content;

            Assert.AreEqual(validationAuth.StatusCode, response.StatusCode);
            Assert.AreEqual(validationAuth.Message, responseContent);
        }
    }
}
