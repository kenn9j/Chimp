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
    public class ChimpRemote : IChimpRemote
    {
        private string _url;
        private string _deviceIp;
        MonkeyTalkWirePayload _payload; 

        public ChimpRemote(string url, string deviceIp)
        {
            this._url = url;
            this._deviceIp = deviceIp;
        }

        public ChimpReturnMessage Play(MonkeyTalkWirePayload payload)
        {

            string res = Post(_url, _deviceIp, JObject.FromObject(payload).ToString());
            var j = JsonConvert.DeserializeObject<ChimpReturnMessage>(res);
            return j;
        }

        public ChimpReturnMessage Record(MonkeyTalkWirePayload payload)
        {
            throw new NotImplementedException();
        }

        public ChimpReturnMessage Ping(MonkeyTalkWirePayload payload)
        {
            throw new NotImplementedException();
        }

        public ChimpReturnMessage Play(string action)
        {
            _payload = new MonkeyTalkWirePayload { mtcommand = MonkeyTalkCommand.PLAY, mtversion = "1" };
            ChimpAction a = ChimpAction.Tap;
            Enum.TryParse<ChimpAction>(action, out a);
            _payload.action = a;
            _payload.mtcommand = MonkeyTalkCommand.PLAY;
            return Play(_payload);
        }

        public ChimpReturnMessage Play(ChimpAction action)
        {
            _payload = new MonkeyTalkWirePayload { mtcommand = MonkeyTalkCommand.PLAY, mtversion = "1" };
            _payload.action = action;
            _payload.mtcommand = MonkeyTalkCommand.PLAY;
            return Play(_payload);
        }

        public IChimpRemote Element(string componentType, string monkeyId)
        {
            _payload = new MonkeyTalkWirePayload { mtversion = "1" };
            _payload.componentType = (MonkeyTalkComponent)Enum.Parse(typeof(MonkeyTalkComponent), componentType);
            _payload.monkeyId = monkeyId;
            return this;
        }

        public IChimpRemote Element(MonkeyTalkComponent componentType, string monkeyId)
        {
            throw new NotImplementedException();
        }

        public IChimpRemote With(string args)
        {
            _payload.args = args.Split(',');
            return this;
        }

        public IChimpRemote With(string args, string modifiers)
        {
            _payload.args = args.Split(',');
            //todo: _payload.modifiers = modifiers.ToDictionary
            return this;
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

        public IChimpAction Button(string monkeyId)
        {
            throw new NotImplementedException();
        }

        public IChimpArgs Slider(string monkeyId)
        {
            throw new NotImplementedException();
        }

        public IChimpArgs TextField(string monkeyId)
        {
            throw new NotImplementedException();
        }

        public IChimpArgs Checkbox(string monkeyId)
        {
            throw new NotImplementedException();
        }

        public IChimpElement Tap()
        {
            throw new NotImplementedException();
        }

        public ChimpReturnMessage TouchUp()
        {
            throw new NotImplementedException();
        }

        public ChimpReturnMessage TouchDown()
        {
            throw new NotImplementedException();
        }

        public ChimpReturnMessage SwipeLeft()
        {
            throw new NotImplementedException();
        }

        public ChimpReturnMessage SwipeRight()
        {
            throw new NotImplementedException();
        }


        IChimpArgs IChimpRemote.Element(string componentType, string monkeyId)
        {
            throw new NotImplementedException();
        }

        IChimpArgs IChimpRemote.Element(MonkeyTalkComponent componentType, string monkeyId)
        {
            throw new NotImplementedException();
        }


        ChimpReturnMessage IChimpAction.Tap()
        {
            throw new NotImplementedException();
        }
    }
}
