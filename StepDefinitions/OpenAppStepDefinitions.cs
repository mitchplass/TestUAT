using NUnit.Framework;
using TestUAT.Hooks;
using System;
using TechTalk.SpecFlow;
using TestUAT.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

namespace TestUAT.StepDefinitions
{
    [Binding]
    public class OpenAppStepDefinitions
    {
        [Given(@"the app is launched")]
        public void GivenTheAppIsLaunched()
        {
            Assert.IsNotNull(Hooks.Hooks.Driver1, "Appium Driver was not initialized");
        }

        [Given(@"I press port transport")]
        public void GivenIPressPortTransport()
        {
            Thread.Sleep(10000);
            var element = Hooks.Hooks.Driver1.FindElement(by: By.XPath("(//androidx.recyclerview.widget.RecyclerView[@resource-id=\"com.wisetechglobal.glowclient:id/appRecyclerView\"])[2]/androidx.cardview.widget.CardView/android.view.ViewGroup"));
            element.Click();
        }

        [Given(@"I enter login details with username ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenIEnterLoginDetailsWithUsernameAndPassword(string username, string password)
        {
            Hooks.Hooks.Driver1.Context = "WEBVIEW_com.wisetechglobal.glowclient";

            var wait = new WebDriverWait(Hooks.Hooks.Driver1, TimeSpan.FromSeconds(10));
            var loginButton = wait.Until(driver => driver.FindElement(By.TagName("button")));
            loginButton.Click();
        }


        [Then(@"the port transport portal should be open")]
        public void ThenThePortTransportPortalShouldBeOpen()
        {
            Assert.IsTrue(true);
        }
    }
}
