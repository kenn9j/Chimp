using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chimp.WebAPI.Controllers
{
    public class MockMonkeyTalkAgentController : ApiController
    {
        // GET api/mockmonkeytalkagent
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/mockmonkeytalkagent/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/mockmonkeytalkagent
        public string Post([FromBody]string value)
        {
            return System.Web.Helpers.Json.Encode( new Chimp.Core.MonkeyTalkWireReturn() { message = "Love it", result = "OK" }  );
        }

        // PUT api/mockmonkeytalkagent/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/mockmonkeytalkagent/5
        public void Delete(int id)
        {
        }
    }
}
