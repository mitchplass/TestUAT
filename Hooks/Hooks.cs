using OpenQA.Selenium.Appium;
using TestUAT.Drivers;

namespace TestUAT.Hooks
{
    [Binding]
    public class Hooks
    {
        public static AppiumDriver Driver;

        [BeforeScenario]
        public void Setup()
        {
            string platform = "android";
            Driver = AppiumDriverFactory.CreateDriver(platform);
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
