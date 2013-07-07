using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Chimp.Core
{
    public interface IMonkeyTalkAgent
    {
        MonkeyTalkWireReturn Play(MonkeyTalkWirePayload payload);
        MonkeyTalkWireReturn Record(MonkeyTalkWirePayload payload);
        MonkeyTalkWireReturn Ping(MonkeyTalkWirePayload payload);

    }

    public class MockMonkeyTalkAgent : IMonkeyTalkAgent
    {
        public MonkeyTalkWireReturn Play(MonkeyTalkWirePayload payload)
        {
            throw new NotImplementedException();
        }

        public MonkeyTalkWireReturn Record(MonkeyTalkWirePayload payload)
        {
            throw new NotImplementedException();
        }

        public MonkeyTalkWireReturn Ping(MonkeyTalkWirePayload payload)
        {
            throw new NotImplementedException();
        }
    }
}
