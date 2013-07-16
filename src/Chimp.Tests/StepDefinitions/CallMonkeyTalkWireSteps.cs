using System;
using TechTalk.SpecFlow;
using Moq;
using Chimp.Core;
using Newtonsoft;
using NUnit.Framework;
using Autofac;

namespace Chimp.Tests.StepDefinitions
{
    [Binding]
    public class CallMonkeyTalkWireSteps
    {

        IMonkeyTalkRemote _monkeyTalkRemote;
        MonkeyTalkWireReturn _monkeyTalkReturnMessage;
        Moq.Mock<IMonkeyTalkRemote> _mock;
        MonkeyTalkWirePayload _payload;
        bool _useMock;
 

        [Given(@"I have a running MonkeyTalk Remote at location ""(.*)""")]
        public void GivenIHaveARunningMonkeyTalkRemoteAtLocation(string location)
        {
            if (location == "mock")
            {
                _mock = new Moq.Mock<IMonkeyTalkRemote>();
            }
            else
            {
                _monkeyTalkRemote = new ChimpRemote(location, string.Empty); //string.Empty should be deviceIp from Devs config file.
            }
            if (_payload == null) _payload = new MonkeyTalkWirePayload();
        }

        [When(@"I send a simple play command payload")]
        public void WhenISendASimplePlayCommandPayload()
        {
            //default payload - Tap and call Play
            _payload = new MonkeyTalkWirePayload() { action = MonkeyTalkAction.Tap, mtcommand = MonkeyTalkCommand.PLAY };
            _mock.Setup(x => x.Play(_payload)).Returns(new MonkeyTalkWireReturn() { result = "OK", message = "mocked test result" });
            _monkeyTalkRemote = _mock.Object;
            _monkeyTalkReturnMessage = _monkeyTalkRemote.Play(_payload);
        }

        [Given(@"I want to send a ""(.*)"" command")]
        public void GivenIWantToSendACommand(string p0)
        {
            _payload.mtcommand = (MonkeyTalkCommand)Enum.Parse(typeof(MonkeyTalkCommand), p0.ToUpper());
        }

        
        [Then(@"the result should be ""(.*)""")]
        public void ThenTheResultShouldBe(string p0)
        {
            Assert.IsTrue(_monkeyTalkReturnMessage.result == p0);
        }

        [Given(@"the componentType is ""(.*)""")]
        public void GivenTheComponentTypeIs(string p0)
        {
            _payload.componentType = (MonkeyTalkComponent)Enum.Parse(typeof(MonkeyTalkComponent), p0);
        }

        [Given(@"the monkeyId is ""(.*)""")]
        public void GivenTheMonkeyIdIs(string p0)
        {
            _payload.monkeyId = p0;
        }

        [Given(@"the payload arguments are ""(.*)""")]
        public void GivenThePayloadArgumentsAre(string p0)
        {
            _payload.args = p0.Split(',');
        }


        [When(@"I send a ""(.*)"" action with the payload")]
        public void WhenISendAActionWithThePayload(string p0)
        {
            MonkeyTalkAction action = MonkeyTalkAction.Tap;
            Enum.TryParse<MonkeyTalkAction>(p0, out action);
            _payload.action = action;

            if (_mock != null)
            {
                _mock.Setup(x => x.Play(_payload))
                    .Returns(new MonkeyTalkWireReturn() { result = "OK" });

                _monkeyTalkRemote = _mock.Object;
            }

            _monkeyTalkReturnMessage = _monkeyTalkRemote.Play(_payload);

            //app.Button("butonId").Tap().With("ssasasas");
        }

        

        //When I send a Play command to "<action>" "<componentType>" "<monkeyId>" with "<args>"
        [When(@"I send a Play command to ""(.*)"" ""(.*)"" ""(.*)"" with ""(.*)""")]
        public void WhenISendAPlayCommandToWith(string action, string componentType, string monkeyId, string args)
        {
            _monkeyTalkReturnMessage = _monkeyTalkRemote.For(componentType, monkeyId).With(args).Play(action);
        }



    }
}
