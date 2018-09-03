using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestProj {
    class ResponseHandler {

        public void HTTPRequest(object sender, Task<HttpResponseMessage> obj) {
            Console.WriteLine("HTTP Response");
            Console.WriteLine(obj.Result.Content.ReadAsStringAsync().Result);
        }

    }
}
