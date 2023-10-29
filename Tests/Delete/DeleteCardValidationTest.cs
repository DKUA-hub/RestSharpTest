using NUnit.Framework;
using RestSharp;
using RestSharpTest.Arguments.Holders;
using RestSharpTest.Arguments.Providers;
using RestSharpTest.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Tests.Delete
{
    internal class DeleteCardValidationTest : BaseClass
    {
        [Test]
        [TestCaseSource(typeof(CardIdArgumentsProvider))]
        public void TestDeleteCardWithInvalidName(CardIdArgumentsHolder deleteArguments)
        {
            var request = RequestWithAuth(CardsEndpoints.DELETE_CARD)
                .AddOrUpdateParameters(deleteArguments.PathParams);
            var response = _client.Delete(request);

            Assert.AreEqual(deleteArguments.StatusCode, response.StatusCode);
            Assert.AreEqual(deleteArguments.ErrorMessage, response.Content);
        }

        [Test]
        [TestCaseSource(typeof(CardAuthArgumentsProvider))]
        public void TestDeleteCardWithInvalidAuth(AuthArgumentsHolder deleteArguments)
        {
            var request = RequestWithoutAuth(CardsEndpoints.DELETE_CARD)
                .AddOrUpdateParameters(deleteArguments.AuthParams)
                .AddOrUpdateParameters(deleteArguments.PathParameter);
            var response = _client.Delete(request);

            Assert.AreEqual(deleteArguments.StatusCode, response.StatusCode);
            Assert.AreEqual(deleteArguments.Message, response.Content);
        }
    }
}
