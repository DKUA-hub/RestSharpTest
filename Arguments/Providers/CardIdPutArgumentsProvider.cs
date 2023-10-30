using RestSharp;
using RestSharpTest.Arguments.Holders;
using RestSharpTest.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Arguments.Providers
{
    internal class CardIdPutArgumentsProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new CardIdPutArgumentsHolder()
                {
                    PathParam = new[] { Parameter.CreateParameter("cardId", UrlParametersValues.INVALID_CARD_ID, ParameterType.UrlSegment) },
                    Body = new Dictionary<string, object> { { "name", "QA Framework: updated card name"} },
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "invalid id"
                }
            };

            /*yield return new object[]
            {
                new CardIdPutArgumentsHolder()
                {
                    PathParam = new[] { Parameter.CreateParameter("cardId", string.Empty, ParameterType.UrlSegment)},
                    Body = new Dictionary<string, object> {{ "name", "QA Framework: updated card name"}},
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"Cannot PUT /1/cards/?key={UrlParametersValues.VALID_KEY}&token={UrlParametersValues.VALID_TOKEN}"
                }
            };*/

            yield return new object[]
            {
                new CardIdPutArgumentsHolder
                {
                    PathParam = new[] { Parameter.CreateParameter("cardId", UrlParametersValues.ANOTHER_USER_CARD_ID, ParameterType.UrlSegment)},
                    Body = new Dictionary<string, object> {{ "name", "QA Framework: updated card name"}},
                    StatusCode = HttpStatusCode.Unauthorized,
                    Message = "unauthorized card permission requested"
                }
            };

            yield return new object[]
            {
                new CardIdPutArgumentsHolder
                {
                    PathParam = new[] { Parameter.CreateParameter("cardId", UrlParametersValues.CARD_ID, ParameterType.UrlSegment)},
                    Body = new Dictionary<string, object> {{ "name", 12345}},
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "invalid value for name"
                }
            };
        }
    }
}
