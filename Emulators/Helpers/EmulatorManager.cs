using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestUAT.Emulators.Types;

namespace TestUAT.Emulators.Helpers
{
    public static class EmulatorManager
    {
        public static ThreadLocal<AppiumDriver> Driver = new ThreadLocal<AppiumDriver>();

        public static void StartDriver(EmulatorVersions version)
        {
            var driver = EmulatorFactory.StartDriver(version) ?? throw new Exception("Failed to start driver");
            Driver.Value = driver;
        }

        public static void CloseDriver()
        {
            var driver = Driver.Value;
            driver.Quit();
            driver.Dispose();
        }
    }
}
