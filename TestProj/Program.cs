using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestProj {
    class Program {
        static void Main(string[] args) {
            SimpleRest restObj = new SimpleRest();
            ResponseHandler responseHandler = new ResponseHandler();

            restObj.OnCallback += responseHandler.HTTPRequest;
            restObj.Get("https://httpbin.org/get");

            restObj.GetCallBack("https://httpbin.org/get", responseObj => {
                Console.WriteLine("Callback with delegate");
                Console.WriteLine(responseObj.Result.Content.ReadAsStringAsync().Result);
            });

            Console.ReadKey();
        }
    }
}
