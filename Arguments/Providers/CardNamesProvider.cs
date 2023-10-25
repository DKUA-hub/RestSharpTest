using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using RestSharpTest.Arguments.Holders;
using RestSharpTest.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Arguments.Providers
{
    internal class CardNamesProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            /*yield return new CardNamesHolder
            {
                RequestBody = new Dictionary<string, object>[]
                {
                    ImmutableDictionary<string, object>.Empty.ToDictionary<string, object>(null)
                },
                Message = "invalid value for name"
            };*/

            yield return new object[]
            {
                new CardNamesHolder
                {
                    RequestBody = new Dictionary<string, object>
                    {
                        { "name", 12345 }
                    },
                    Message = "invalid value for name",
                    StatusCode = HttpStatusCode.BadRequest
                }
            };

            yield return new object[]
            {
                 new CardNamesHolder
                {
                    RequestBody = new Dictionary<string, object>
                    {
                        { "name", "qaFramework New Card" },
                    },
                    Message = "invalid value for idList",
                    StatusCode = HttpStatusCode.BadRequest
                 }
            };

            yield return new object[]
            {
                new CardNamesHolder
                {
                    RequestBody = new Dictionary<string, object>
                    {
                        { "name", "qaFramework New Card" },
                        { "idList", 12345 }
                    },
                    Message = "invalid value for idList",
                    StatusCode = HttpStatusCode.BadRequest
                } 
            };

            yield return new object[]
            {
                new CardNamesHolder
                {
                    RequestBody = new Dictionary<string, object>
                    {
                        { "name", 12345 },
                        { "idList", UrlParametersValues.LIST_ID }
                    },
                    Message = "invalid value for name",
                    StatusCode = HttpStatusCode.BadRequest
                } 
            };

            yield return new object[]
            {
                new CardNamesHolder
                {
                    RequestBody = new Dictionary<string, object>
                    {
                        { "name", "qaFramework New Card" },
                        { "idList", UrlParametersValues.ANOTHER_USER_LIST_ID }
                    },
                    Message = "unauthorized card permission requested",
                    StatusCode = HttpStatusCode.Unauthorized
                } 
            };
        }
    }
}
