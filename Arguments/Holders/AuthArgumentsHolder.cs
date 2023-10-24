using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Arguments.Holders
{
    public class AuthArgumentsHolder
    {
        public IEnumerable<Parameter> AuthParams {  get; set; }

        public IEnumerable<Parameter> PathParameter { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

    }
}
