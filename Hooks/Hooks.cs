using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Support.UI;
using TestUAT.Emulators.Helpers;
using TestUAT.Support;
namespace TestUAT.Hooks
{
    [Binding]
    public class Hooks
    {
        public static ThreadLocal<AppiumDriver> Driver = new ThreadLocal<AppiumDriver>();
        public static ThreadLocal<WebDriverWait> Wait = new ThreadLocal<WebDriverWait>();
        public static ThreadLocal<bool> IsEmulatorRunning = new ThreadLocal<bool>();

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            IsEmulatorRunning.Value = false;
        }

        [BeforeScenario]
        public static void Setup()
        {
            
        }

        [AfterFeature]
        public static void TearDown()
        {
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            EmulatorManager.CloseDriver();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts", "KillAndDeleteEmulators.ps1");
            CommandHelper.RunKillEmulatorPowershellScript(path);
        }
    }
}