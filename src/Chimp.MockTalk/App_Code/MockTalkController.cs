using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

/// <summary>
/*
/// JSON payload:

{
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
}
 

mtversion	“1”, currently the only possible value
mtcommand	“PLAY” for playback
componentType	the MonkeyTalk componentType as a String
monkeyId	the MonkeyTalk monkeyId as a String
action	the MonkeyTalk action as a String
args	(optional) the MonkeyTalk argument list as an JSON Array
modifiers	(optional) the MonkeyTalk modifiers as a JSON Hash with String keys and String values
 

Returns:

{
  result:"OK",
  message:"Some message"
}
 

result	either OK, ERROR, FAILURE where FAILURE only occurs on a failed Verify action
message	(optional) usually blank on OK (except for the Get action), otherwise contains an error description

*/
/// </summary>
public class MockTalkController : ApiController
{

    public MockTalkController()
    {
        //JsonToken returnMessageTemplateJson = new JsonToken();
    }

    /// <summary>
    /// result	either OK, ERROR, FAILURE where FAILURE only occurs on a failed Verify action
    /// message	(optional) usually blank on OK (except for the Get action), otherwise contains an error description
    /// </summary>
    static readonly string returnMessageTemplate = @"{  result:'{0}',  message:'{1}'}"; //todo: as JSON



    // GET api/<controller>
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<controller>/5
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<controller>
    public void Post([FromBody]string value)
    {
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
    }
}
