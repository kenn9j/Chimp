using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Chimp.Core
{
    public class Driver
    {
        
        
    }


    /// <summary>
    /// 
    /* {
  mtversion:1,
  mtcommand:"PLAY",
  componentType:"Button",
  monkeyId:"OK",
  action:"Tap",
  args:["17","33"],
  modifiers:{
    timeout:"123",
    thinktime:"654"
  }
} */
    /// </summary>
     [JsonObject]
    public class MonkeyTalkWirePayload
    {
        public string mtversion;
        public MonkeyTalkCommand mtcommand;
        public MonkeyTalkComponent componentType;
        public string monkeyId;
        public MonkeyTalkAction action;
        public string[] args;
        public Dictionary<string,string> modifiers;
    }

    /*
     * {
  result:"OK",
  message:"Some message"
     * 
     * result	either OK, ERROR, FAILURE where FAILURE only occurs on a failed Verify action
message	(optional) usually blank on OK (except for the Get action), otherwise contains an error description

}
     * */
    [JsonObject]
    public class MonkeyTalkWireReturn
    {
        public string result;
        public string message;
    }

    public enum MonkeyTalkWireResult
    {
        OK, ERROR, FAILURE
    }

    public enum MonkeyTalkCommand
    {
        PLAY,
        RECORD,
        PING
    }

    public enum MonkeyTalkComponent
    {
        Button
    }
    
    public enum MonkeyTalkAction
    { 
        Tap, 
        TouchUp
    }
}
