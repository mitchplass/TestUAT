using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Support.UI;
using TestUAT.Emulators.Helpers;
namespace TestUAT.Hooks
{
    [Binding]
    public class Hooks
    {
        public static ThreadLocal<AppiumDriver> Driver = new ThreadLocal<AppiumDriver>();
        public static ThreadLocal<WebDriverWait> Wait = new ThreadLocal<WebDriverWait>();

        [BeforeScenario]
        public static void Setup()
        {
            
        }

        [AfterFeature]
        public static void TearDown()
        {
            EmulatorManager.CloseDriver();
        }
    }
}