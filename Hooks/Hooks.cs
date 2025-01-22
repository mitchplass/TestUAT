using OpenQA.Selenium.Appium;
using TestUAT.Drivers;

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
            //Driver2 = AppiumDriverFactory.CreateDriver(platform, "G23C51251", "1001");
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver1.Quit();
            //Driver2.Quit();
        }
    }
}
