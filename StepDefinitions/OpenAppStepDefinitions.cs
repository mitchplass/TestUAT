using NUnit.Framework;
using TechTalk.SpecFlow;
using TestUAT.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using TestUAT.Emulators.Types;
using TestUAT.Emulators.Helpers;
using BoDi;
using TestUAT.Emulators.Drivers;
using TestUAT.Emulators.Interfaces;

namespace TestUAT.StepDefinitions
{
    [Binding]
    public class OpenAppStepDefinitions
    {
        ThreadLocal<AppiumDriver> driver = new ThreadLocal<AppiumDriver>();
        ThreadLocal<WebDriverWait> wait = new ThreadLocal<WebDriverWait>();


        [Given(@"the app is launched using ""([^""]*)""")]
        public void GivenTheAppIsLaunchedUsing(string versionString)
        {
            if (Enum.TryParse(versionString, out EmulatorVersions version))
            {
                EmulatorManager.StartDriver(version);
                driver = EmulatorManager.Driver;
                wait.Value = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(20));

                if (version == EmulatorVersions.Android10)
                {
                    ADBHelper.RunADBCommand($"-s emulator-5554 shell am start -n com.wisetechglobal.glowclient/.FullscreenWebActivity");
                }
                else
                {
                    ADBHelper.RunADBCommand($"-s emulator-5556 shell am start -n com.wisetechglobal.glowclient/.FullscreenWebActivity");
                }
            }
            else
            {
                Assert.Fail("Android version does not exist: " + versionString);
            }

            Assert.IsNotNull(driver.Value, "Appium Driver was not initialized");
        }


        [Given(@"I press port transport")]
        public void GivenIPressPortTransport()
        {
            NavigationHelper.ElementWaitAndClick(By.XPath("(//androidx.recyclerview.widget.RecyclerView[@resource-id=\"com.wisetechglobal.glowclient:id/appRecyclerView\"])[2]/androidx.cardview.widget.CardView/android.view.ViewGroup"), wait.Value);
        }

        [Given(@"I enter login details with username ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenIEnterLoginDetailsWithUsernameAndPassword(string username, string password)
        {
            foreach (var context in driver.Value.Contexts)
            {
                Console.WriteLine(context);
            }

            driver.Value.Context = "WEBVIEW_com.wisetechglobal.glowclient";

            NavigationHelper.ElementWaitAndClick(By.TagName("button"), wait.Value);
            NavigationHelper.ElementWaitAndSendKeys(By.CssSelector("#i0116"), username, wait.Value);
            NavigationHelper.ElementWaitAndClick(By.CssSelector("#idSIButton9"), wait.Value);
            NavigationHelper.ElementWaitAndSendKeys(By.CssSelector("#i0118"), password, wait.Value);
            NavigationHelper.ElementWaitAndClick(By.CssSelector("#idSIButton9"), wait.Value);
        }

        [Given(@"I select account ""([^""]*)""")]
        public void GivenISelectCWSupport(string account)
        {
            Thread.Sleep(20000);
            NavigationHelper.ElementWaitAndClick(By.XPath($"//*[text()='{account}']"), wait.Value);
        }


        [Then(@"the port transport portal should be open")]
        public void ThenThePortTransportPortalShouldBeOpen()
        {
            Assert.IsNotNull(NavigationHelper.WaitForElement(By.XPath("//*[text()='Port Transport Mobile']"), wait.Value));
        }
    }
}
