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
            NavigationHelper.ElementWaitAndClick(By.XPath("(//androidx.recyclerview.widget.RecyclerView[@resource-id=\"com.wisetechglobal.glowclient:id/appRecyclerView\"])[2]/androidx.cardview.widget.CardView/android.view.ViewGroup"));
        }

        [Given(@"I enter login details with username ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenIEnterLoginDetailsWithUsernameAndPassword(string username, string password)
        {
            Hooks.Hooks.Driver1.Context = "WEBVIEW_com.wisetechglobal.glowclient";

            NavigationHelper.ElementWaitAndClick(By.TagName("button"));
            NavigationHelper.ElementWaitAndSendKeys(By.CssSelector("#i0116"), username);
            NavigationHelper.ElementWaitAndClick(By.CssSelector("#idSIButton9"));
            NavigationHelper.ElementWaitAndSendKeys(By.CssSelector("#i0118"), password);
            NavigationHelper.ElementWaitAndClick(By.CssSelector("#idSIButton9"));
        }

        [Given(@"I select account ""([^""]*)""")]
        public void GivenISelectCWSupport(string account)
        {
            Thread.Sleep(20000);
            NavigationHelper.ElementWaitAndClick(By.XPath($"//*[text()='{account}']"));
        }


        [Then(@"the port transport portal should be open")]
        public void ThenThePortTransportPortalShouldBeOpen()
        {
            Assert.IsNotNull(NavigationHelper.WaitForElement(By.XPath("//*[text()='Port Transport Mobile']")));
        }
    }
}
