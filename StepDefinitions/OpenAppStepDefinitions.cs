using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestUAT.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using TestUAT.Emulators.Types;
using TestUAT.Emulators.Helpers;
using BoDi;

namespace TestUAT.StepDefinitions
{
    [TestFixture(EmulatorVersions.Android8)]
    [Parallelizable(ParallelScope.Fixtures)]
    [Binding]
    public class OpenAppStepDefinitions
    {
        readonly EmulatorVersions version;

        public OpenAppStepDefinitions(EmulatorVersions version)
        {
            this.version = version;
        }
        
        AndroidDriver driver;
        WebDriverWait wait;

        [BeforeScenario]
        public void Setup() 
        {
            EmulatorManager.StartDriver(version);
            driver = EmulatorManager.GetDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
        
        [Given(@"the app is launched")]
        public void GivenTheAppIsLaunched()
        {
            Assert.IsNotNull(driver, "Appium Driver was not initialized");
        }

        [Given(@"I press port transport")]
        public void GivenIPressPortTransport()
        {
            NavigationHelper.ElementWaitAndClick(By.XPath("(//androidx.recyclerview.widget.RecyclerView[@resource-id=\"com.wisetechglobal.glowclient:id/appRecyclerView\"])[2]/androidx.cardview.widget.CardView/android.view.ViewGroup"), wait);
        }

        [Given(@"I enter login details with username ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenIEnterLoginDetailsWithUsernameAndPassword(string username, string password)
        {
            foreach (var context in driver.Contexts)
            {
                Console.WriteLine(context);
            }

            driver.Context = "WEBVIEW_com.wisetechglobal.glowclient";

            NavigationHelper.ElementWaitAndClick(By.TagName("button"), wait);
            NavigationHelper.ElementWaitAndSendKeys(By.CssSelector("#i0116"), username, wait);
            NavigationHelper.ElementWaitAndClick(By.CssSelector("#idSIButton9"), wait);
            NavigationHelper.ElementWaitAndSendKeys(By.CssSelector("#i0118"), password, wait);
            NavigationHelper.ElementWaitAndClick(By.CssSelector("#idSIButton9"), wait);
        }

        [Given(@"I select account ""([^""]*)""")]
        public void GivenISelectCWSupport(string account)
        {
            Thread.Sleep(20000);
            NavigationHelper.ElementWaitAndClick(By.XPath($"//*[text()='{account}']"), wait);
        }


        [Then(@"the port transport portal should be open")]
        public void ThenThePortTransportPortalShouldBeOpen()
        {
            Assert.IsNotNull(NavigationHelper.WaitForElement(By.XPath("//*[text()='Port Transport Mobile']"), wait));
        }
    }
}
