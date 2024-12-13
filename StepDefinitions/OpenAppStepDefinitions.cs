using NUnit.Framework;
using TestUAT.Hooks;
using System;
using TechTalk.SpecFlow;

namespace TestUAT.StepDefinitions
{
    [Binding]
    public class OpenAppStepDefinitions
    {
        [Given(@"the app is launched")]
        public void GivenTheAppIsLaunched()
        {
            Assert.IsNotNull(Hooks.Hooks.Driver, "Appium Driver was not initialized");
        }

        [Then(@"the app should be open")]
        public void ThenTheAppShouldBeOpen()
        {
            Assert.IsNotNull(Hooks.Hooks.Driver.Context, "The app did not open correctly");
        }
    }
}
