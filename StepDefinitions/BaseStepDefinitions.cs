using NUnit.Framework;
using TestUAT.Support;
using OpenQA.Selenium.Support.UI;
using TestUAT.Emulators.Types;
using TestUAT.Emulators.Helpers;

using Base = TestUAT.Hooks.Hooks;

namespace TestUAT.StepDefinitions
{
    [Binding]
    public class BaseStepDefinitions
    {
        [Given(@"the app is launched using ""([^""]*)""")]
        public void GivenTheAppIsLaunchedUsing(string versionString)
        {
            if (Enum.TryParse(versionString, out EmulatorVersions version))
            {
                EmulatorManager.StartDriver(version);
                Base.Wait.Value = new WebDriverWait(Base.Driver.Value, TimeSpan.FromSeconds(20));

                var uuid = Base.Driver.Value.Capabilities.GetCapability("udid").ToString();
                ADBHelper.RunADBCommand($"-s {uuid} shell am start -n com.wisetechglobal.glowclient/.FullscreenWebActivity");
            }
            else
            {
                Assert.Fail("Android version does not exist: " + versionString);
            }

            Assert.IsNotNull(Base.Driver.Value, "Appium Driver was not initialized");
        }
    }
}
