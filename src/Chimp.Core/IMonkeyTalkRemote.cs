using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Chimp.Core
{
    public interface IMonkeyTalkRemote
    {
        MonkeyTalkWireReturn Play(MonkeyTalkWirePayload payload);
        MonkeyTalkWireReturn Record(MonkeyTalkWirePayload payload);
        MonkeyTalkWireReturn Ping(MonkeyTalkWirePayload payload);

        MonkeyTalkWireReturn Play(string action);
        MonkeyTalkWireReturn Play(MonkeyTalkAction action);
        IMonkeyTalkRemote For(string componentType, string monkeyId);
        IMonkeyTalkRemote For(MonkeyTalkComponent componentType, string monkeyId);
        IMonkeyTalkRemote With(string args);

    }

    public class MockMonkeyTalkAgent : IMonkeyTalkRemote
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


        public IMonkeyTalkRemote Play(string action)
        {
            throw new NotImplementedException();
        }

        public IMonkeyTalkRemote For(string componentType, string monkeyId)
        {
            throw new NotImplementedException();
        }

        public IMonkeyTalkRemote With(string args)
        {
            throw new NotImplementedException();
        }


        public MonkeyTalkWireReturn Play()
        {
            throw new NotImplementedException();
        }


        public IMonkeyTalkRemote Play(MonkeyTalkAction action)
        {
            throw new NotImplementedException();
        }

        public IMonkeyTalkRemote For(MonkeyTalkComponent componentType, string monkeyId)
        {
            throw new NotImplementedException();
        }


        MonkeyTalkWireReturn IMonkeyTalkRemote.Play(string action)
        {
            throw new NotImplementedException();
        }

        MonkeyTalkWireReturn IMonkeyTalkRemote.Play(MonkeyTalkAction action)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMonkeyTalkComponentList
    {
         IMonkeyTalkComponentAction Button(string monkeyId);
         IMonkeyTalkComponentAction Slider(string monkeyId);
         IMonkeyTalkComponentAction TextField(string monkeyId);
         IMonkeyTalkComponentAction Checkbox(string monkeyId);
///..
///

    }

    public interface IMonkeyTalkComponentAction
    {
         IMonkeyTalkComponentAction With(string args);
         IMonkeyTalkComponentAction With(string args, Dictionary<string, string> modifiers );
         MonkeyTalkWireReturn Tap();
         MonkeyTalkWireReturn TouchUp();
         MonkeyTalkWireReturn TouchDown();
         MonkeyTalkWireReturn SwipeLeft();
         MonkeyTalkWireReturn SwipeRight();
    }


}
