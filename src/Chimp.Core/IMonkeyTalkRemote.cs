using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Chimp.Core
{
    public interface IChimpRemote : IChimpElement, IChimpAction
    {
        ChimpReturnMessage Play(MonkeyTalkWirePayload payload);
        ChimpReturnMessage Record(MonkeyTalkWirePayload payload);
        ChimpReturnMessage Ping(MonkeyTalkWirePayload payload);


        IChimpArgs Element(string componentType, string monkeyId);
        IChimpArgs Element(MonkeyTalkComponent componentType, string monkeyId);

        //IChimpRemote With(string args);
        //IChimpRemote With(string args, Dictionary<string, string> modifiers);

    }

    public interface IChimpElement
    {
        IChimpRemote Element(string componentType, string monkeyId);
        IChimpRemote Element(MonkeyTalkComponent componentType, string monkeyId);

        IChimpAction Button(string monkeyId);
        IChimpArgs Slider(string monkeyId);
        IChimpArgs TextField(string monkeyId);
        IChimpArgs Checkbox(string monkeyId);
///..
///

    }
    public interface IChimpArgs
    {
         IChimpAction With(string args);
         IChimpAction With(string args, Dictionary<string, string> modifiers );
    }
    public interface IChimpAction
    {
        ChimpReturnMessage Play(string action);
        ChimpReturnMessage Play(ChimpAction action);

         ChimpReturnMessage Tap();
         ChimpReturnMessage TouchUp();
         ChimpReturnMessage TouchDown();
         ChimpReturnMessage SwipeLeft();
         ChimpReturnMessage SwipeRight();
    }
}
