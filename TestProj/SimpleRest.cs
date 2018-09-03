using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestProj {
    class SimpleRest {


        public interface IGetCallBack {
            void RunCallback(Task<HttpResponseMessage> obj);
        }

        public delegate void GetCallback(Task<HttpResponseMessage> obj);
        public event EventHandler<Task<HttpResponseMessage>> OnCallback;

        private HttpClient dataObj;

        public SimpleRest() {
            dataObj = new HttpClient();
        }

        protected virtual void OnHTTPCallback(Task<HttpResponseMessage> obj) {
            Console.WriteLine("Doing callback");
            OnCallback(this, obj);
        }

        public void Get(string url) {

            var result = dataObj.GetAsync(url);

            result.ContinueWith(OnHTTPCallback);

            //this.OnCallback(this, "sidjf");
        }

        public void GetCallBack(string url, GetCallback callBack) {
            var result = dataObj.GetAsync(url);
            // obj.Invoke(result);
            callBack(result);
        }
    }
}
