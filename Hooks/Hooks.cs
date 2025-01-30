using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using TestUAT.Drivers;
using TestUAT.Support;

namespace TestUAT.Hooks
{
    [Binding]
    public class Hooks
    {
        public static AppiumDriver Driver1;
        public static WebDriverWait Wait;
        //public static AppiumDriver Driver2;

        [BeforeScenario]
        public void Setup()
        {
            string platform = "android";
            Driver1 = AppiumDriverFactory.CreateDriver(platform, "emulator-5554", "1000");
            Wait = new WebDriverWait(Driver1, TimeSpan.FromSeconds(20));

            ADBHelper.RunADBCommand("shell appops set com.wisetechglobal.glowclient MANAGE_EXTERNAL_STORAGE allow");
            ADBHelper.RunADBCommand("shell am start -n com.wisetechglobal.glowclient/.FullscreenWebActivity");

        }

        [AfterScenario]
        public void TearDown()
        {
            Driver1.Quit();
            //Driver2.Quit();
        }
    }
}
