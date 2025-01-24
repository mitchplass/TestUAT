using OpenQA.Selenium.Appium;
using TestUAT.Drivers;
using TestUAT.Support;

namespace TestUAT.Hooks
{
    [Binding]
    public class Hooks
    {
        public static AppiumDriver Driver1;
        //public static AppiumDriver Driver2;

        [BeforeScenario]
        public void Setup()
        {
            string platform = "android";
            //Driver1 = AppiumDriverFactory.CreateDriver(platform, "23010522512714", "1000");
            Driver1 = AppiumDriverFactory.CreateDriver(platform, "emulator-5554", "1000");
            ADBHelper.RunADBCommand("shell appops set com.wisetechglobal.glowclient MANAGE_EXTERNAL_STORAGE allow");
            ADBHelper.RunADBCommand("shell am start -n com.wisetechglobal.glowclient/.FullscreenWebActivity");
            //Driver2 = AppiumDriverFactory.CreateDriver(platform, "G23C51251", "1001");

            //Driver1.InstallApp("C:\\git\\wtg\\Glow\\Glow\\Mobility\\Android\\GlowClient\\app\\build\\outputs\\apk\\debug\\app-debug.apk");
            //ADBHelper.RunADBCommand("")
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver1.Quit();
            //Driver2.Quit();
        }
    }
}
