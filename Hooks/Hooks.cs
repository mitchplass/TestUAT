using OpenQA.Selenium.Appium;
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
        public void Setup()
        {
            
        }
        [AfterScenario]
        public void TearDown()
        {
            EmulatorManager.CloseDriver();
        }
    }
}