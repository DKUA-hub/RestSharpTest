using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Arguments.Holders
{
    internal class CardIdPutArgumentsHolder
    {
        public IDictionary<string, object> Body { get; set; }
        public IEnumerable<Parameter> PathParam { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode {  get; set; }

    }
}
