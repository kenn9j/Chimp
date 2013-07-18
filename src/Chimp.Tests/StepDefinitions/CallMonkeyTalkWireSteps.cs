using System;
using TechTalk.SpecFlow;
using Moq;
using Chimp.Core;
using Newtonsoft;
using NUnit.Framework;
using Autofac;
using a = Chimp.Core.ChimpAction; 

namespace Chimp.Tests.StepDefinitions
{
    [Binding]
    public class CallMonkeyTalkWireSteps
    {

        IChimpRemote chimpRemoteDevice;
        ChimpReturnMessage chimpReturnMessage;
        Moq.Mock<IChimpRemote> _mock;
        MonkeyTalkWirePayload _payload;
        bool _useMock;
 

        [Given(@"I have a running MonkeyTalk Remote at location ""(.*)""")]
        public void GivenIHaveARunningMonkeyTalkRemoteAtLocation(string location)
        {
            if (location == "mock")
            {
                _mock = new Moq.Mock<IChimpRemote>();
            }
            else
            {
                chimpRemoteDevice = new ChimpRemote(location, string.Empty); //string.Empty should be deviceIp from Devs config file.
            }
            if (_payload == null) _payload = new MonkeyTalkWirePayload();
        }

        [When(@"I send a simple play command payload")]
        public void WhenISendASimplePlayCommandPayload()
        {
            //default payload - Tap and call Play
            _payload = new MonkeyTalkWirePayload() { action = ChimpAction.Tap, mtcommand = MonkeyTalkCommand.PLAY };
            _mock.Setup(x => x.Play(_payload)).Returns(new ChimpReturnMessage() { result = "OK", message = "mocked test result" });
            chimpRemoteDevice = _mock.Object;
            chimpReturnMessage = chimpRemoteDevice.Play(_payload);
        }

        [Given(@"I want to send a ""(.*)"" command")]
        public void GivenIWantToSendACommand(string p0)
        {
            _payload.mtcommand = (MonkeyTalkCommand)Enum.Parse(typeof(MonkeyTalkCommand), p0.ToUpper());
        }

        
        [Then(@"the result should be ""(.*)""")]
        public void ThenTheResultShouldBe(string p0)
        {
            Assert.IsTrue(chimpReturnMessage.result == p0);
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
            ChimpAction action = ChimpAction.Tap;
            Enum.TryParse<ChimpAction>(p0, out action);
            _payload.action = action;

            if (_mock != null)
            {
                _mock.Setup(x => x.Play(_payload))
                    .Returns(new ChimpReturnMessage() { result = "OK" });

                chimpRemoteDevice = _mock.Object;
            }

            chimpReturnMessage = chimpRemoteDevice.Play(_payload);

            //app.Button("butonId").Tap().With("ssasasas");
        }

        

        //When I send a Play command to "<action>" "<componentType>" "<monkeyId>" with "<args>"
        [When(@"I send a Play command to ""(.*)"" ""(.*)"" ""(.*)"" with ""(.*)""")]
        public void WhenISendAPlayCommandToWith(string action, string componentType, string monkeyId, string args)
        {
            
            chimpReturnMessage = chimpRemoteDevice.Element(componentType, monkeyId).With(args).Play(action);
            chimpReturnMessage = chimpRemoteDevice.Element(MonkeyTalkComponent.Button, "button1").With(args).Play(a.Tap);
            chimpRemoteDevice.Button("id").Tap();
            chimpRemoteDevice.Slider("id").With("args").SwipeRight();

        }



    }
}
