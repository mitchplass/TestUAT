using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using TestUAT.Emulators.Drivers;
using TestUAT.Emulators.Helpers;
using TestUAT.Emulators.Interfaces;
using TestUAT.Emulators.Types;
using TestUAT.Support;
namespace TestUAT.Hooks
{
    [Binding]
    public class Hooks
    {
        public static IEmulator Android10 = new Android10();
        public static IEmulator Android11 = new Android11();

        public static ThreadLocal<AppiumDriver> Driver = new ThreadLocal<AppiumDriver>();
        public static ThreadLocal<WebDriverWait> Wait = new ThreadLocal<WebDriverWait>();
        public static ThreadLocal<bool> IsEmulatorRunning = new ThreadLocal<bool>();

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            
        }

        [BeforeScenario]
        public void Setup()
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