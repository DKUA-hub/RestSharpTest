using System.Net;
using RestSharp;

namespace RestSharpTest.Arguments.Holders
{
    public class CardIdAuthHolder
    {
        public IEnumerable<Parameter> PathParams { get; set; }

        public string ErrorMessage { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Key { get; set; }

        public string Token { get; set; }
    }
}
