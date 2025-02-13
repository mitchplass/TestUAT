using NUnit.Framework;
using TestUAT.Support;
using OpenQA.Selenium;

using Base = TestUAT.Hooks.Hooks;

namespace TestUAT.StepDefinitions
{
    [Binding]
    public class OpenAppStepDefinitions
    {
        [Given(@"I press port transport")]
        public void GivenIPressPortTransport()
        {
            NavigationHelper.ElementWaitAndClick(By.XPath("(//androidx.recyclerview.widget.RecyclerView[@resource-id=\"com.wisetechglobal.glowclient:id/appRecyclerView\"])[2]/androidx.cardview.widget.CardView/android.view.ViewGroup"), Base.Wait.Value);
        }

        [Given(@"I press transit warehouse")]
        public void GivenIPressTransitWarehouse()
        {
            NavigationHelper.ElementWaitAndClick(By.XPath("(//androidx.recyclerview.widget.RecyclerView[@resource-id=\"com.wisetechglobal.glowclient:id/appRecyclerView\"])[1]/androidx.cardview.widget.CardView[3]/android.view.ViewGroup"), Base.Wait.Value);
        }

        [Given(@"I enter login details with username ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenIEnterLoginDetailsWithUsernameAndPassword(string username, string password)
        {
            Base.Driver.Value.Context = "WEBVIEW_com.wisetechglobal.glowclient";

            NavigationHelper.ElementWaitAndClick(By.TagName("button"), Base.Wait.Value);
            NavigationHelper.ElementWaitAndSendKeys(By.CssSelector("#i0116"), username, Base.Wait.Value);
            NavigationHelper.ElementWaitAndClick(By.CssSelector("#idSIButton9"), Base.Wait.Value);
            NavigationHelper.ElementWaitAndSendKeys(By.CssSelector("#i0118"), password, Base.Wait.Value);
            NavigationHelper.ElementWaitAndClick(By.CssSelector("#idSIButton9"), Base.Wait.Value);
        }

        [Given(@"I select account ""([^""]*)""")]
        public void GivenISelectAccount(string account)
        {
            Thread.Sleep(20000);
            NavigationHelper.ElementWaitAndClick(By.XPath($"//*[text()='{account}']"), Base.Wait.Value);
        }


        [Then(@"the port transport portal should be open")]
        public void ThenThePortTransportPortalShouldBeOpen()
        {
            Base.Driver.Value.Context = "WEBVIEW_com.wisetechglobal.glowclient";

            Assert.IsNotNull(NavigationHelper.WaitForElement(By.XPath("//*[text()='Port Transport Mobility']"), Base.Wait.Value));
        }

        [Then(@"the transit warehouse portal should be open")]
        public void ThenTheTransitWarehousePortalShouldBeOpen()
        {
            Base.Driver.Value.Context = "WEBVIEW_com.wisetechglobal.glowclient";

            Assert.IsNotNull(NavigationHelper.WaitForElement(By.XPath("//*[text()='Transit Warehouse - Mobile']"), Base.Wait.Value));
        }
    }
}
