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
        private static ThreadLocal<AndroidDriver> Driver = new ThreadLocal<AndroidDriver>();

        public static AndroidDriver GetDriver()
        {
            return DriverStored;
        }

        private static AndroidDriver DriverStored 
        { 
            get
            {
                if (Driver == null || DriverStored == null)
                {
                    throw new ArgumentException("Call 'StartDriver' first");
                }
                return Driver.Value;
            }
            set
            {
                Driver.Value = value;
            }
        }

        public static void StartDriver(EmulatorVersions version)
        {
            EmulatorFactory.StartDriver(version);
        }

        public static void CloseDriver()
        {
            AndroidDriver driver = DriverStored;
            driver.Quit();
            driver.Dispose();

            if (DriverStored != null)
            {
                DriverStored = null;
            }
        }
    }
}
