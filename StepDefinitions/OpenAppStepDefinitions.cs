using NUnit.Framework;
using TestUAT.Hooks;
using System;
using TechTalk.SpecFlow;
using TestUAT.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestUAT.StepDefinitions
{
    [Binding]
    public class OpenAppStepDefinitions
    {
        [Given(@"the app is launched")]
        public void GivenTheAppIsLaunched()
        {
            ADBHelper.RunADBCommand("shell appops set com.wisetechglobal.glowclient MANAGE_EXTERNAL_STORAGE allow");

            Assert.IsNotNull(Hooks.Hooks.Driver1, "Appium Driver was not initialized");
            //Assert.IsNotNull(Hooks.Hooks.Driver2, "Appium Driver was not initialized");
        }

        [Given(@"I press port transport")]
        public void GivenIPressPortTransport()
        {
            var element = Hooks.Hooks.Driver1.FindElement(by: By.XPath("(//androidx.recyclerview.widget.RecyclerView[@resource-id=\"com.wisetechglobal.glowclient:id/appRecyclerView\"])[2]/androidx.cardview.widget.CardView/android.view.ViewGroup"));
            element.Click();
        }

        [Then(@"the port transport portal should be open")]
        public void ThenThePortTransportPortalShouldBeOpen()
        {
            var currentActivity = Hooks.Hooks.Driver1.Capabilities.GetCapability("activity");

            Assert.IsTrue(currentActivity.ToString().Contains("FullscreenWebActivity"), "The app did not open correctly");
        }
    }
}
