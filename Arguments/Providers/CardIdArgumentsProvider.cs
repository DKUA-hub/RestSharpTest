﻿using System.Collections;
using System.Net;
using RestSharpTest.Arguments.Holders;
using RestSharp;
using RestSharpTest.Constants;

namespace RestSharpTest.Arguments.Providers
{
    public class CardIdArgumentsProvider: IEnumerable
    {
        public IEnumerator GetEnumerator() 
        {
            yield return new object[]
            {
                new CardIdArgumentsHolder
                {
                    ErrorMessage = "invalid id",
                    StatusCode = HttpStatusCode.BadRequest,
                    PathParams = new[] { Parameter.CreateParameter("cardId", "65134c5117c9d3b7f9d2250", ParameterType.UrlSegment)}
                }
            };

            yield return new object[]
            {
                new CardIdArgumentsHolder
                {
                    ErrorMessage = "The requested resource was not found.",
                    StatusCode = HttpStatusCode.NotFound,
                    PathParams = new[] { Parameter.CreateParameter("cardId", "65134c5117c9d3b7f9d22507", ParameterType.UrlSegment)}
                }
            };

/*            yield return new object[]
{
                new CardIdArgumentsHolder
                {
                    ErrorMessage = $"Cannot DELETE /1/cards/?key={UrlParametersValues.VALID_KEY}&token={UrlParametersValues.VALID_TOKEN}",
                    StatusCode = HttpStatusCode.NotFound,
                    PathParams = new[] {new Parameter("cardId", string.Empty, ParameterType.UrlSegment)}
                }
};*/
        }
    }
}
