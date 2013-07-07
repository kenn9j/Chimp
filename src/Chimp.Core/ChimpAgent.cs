using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Chimp.Core
{
    public class ChimpAgent : IMonkeyTalkAgent
    {
        private string _url;
        private string _deviceIp;

        public ChimpAgent(string url, string deviceIp)
        {
            this._url = url;
            this._deviceIp = deviceIp;
        }

        public MonkeyTalkWireReturn Play(MonkeyTalkWirePayload payload)
        {

            string res = Post(_url, _deviceIp, JObject.FromObject(payload).ToString());
            var j = JsonConvert.DeserializeObject<MonkeyTalkWireReturn>(res);
            return j;
        }

        public MonkeyTalkWireReturn Record(MonkeyTalkWirePayload payload)
        {
            throw new NotImplementedException();
        }

        public MonkeyTalkWireReturn Ping(MonkeyTalkWirePayload payload)
        {
            throw new NotImplementedException();
        }

        private string Post(string uri, string filename, string data)
        {
            return Call(uri, filename, data, "POST");
        }

        private string Call(string uri, string filename, string data, string method)
        {
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(Path.Combine(uri, filename));
                httpRequest.Method = method;
                httpRequest.ContentType = "application/json";
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                string byteString = Encoding.UTF8.GetString(bytes);
                // if the URI doesn't exist, an exception will be thrown here...
                httpRequest.ContentLength = bytes.Length;
                Stream os = httpRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);   

                using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                {
                    
                    if (httpResponse.StatusCode != HttpStatusCode.OK)
                    { 
                        //todo: log it?

                    }
                    
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                    {
                        var response = sr.ReadToEnd();
                        
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                // You might want to handle some specific errors : Just pass on up for now...
                throw ex;
            }
        }
    }
}
