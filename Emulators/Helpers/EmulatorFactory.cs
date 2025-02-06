using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUAT.Emulators.Drivers;
using TestUAT.Emulators.Types;

namespace TestUAT.Emulators.Helpers
{
    public static class EmulatorFactory
    {
        public static AppiumDriver StartDriver(EmulatorVersions version)
        {
            AppiumDriver driver;

            switch (version)
            {
                case EmulatorVersions.Android8:
                    throw new NotImplementedException();
                case EmulatorVersions.Android10:
                    driver = new Android10().StartDriver();
                    return driver;
                case EmulatorVersions.Android11:
                    driver = new Android11().StartDriver();
                    return driver;
                default:
                    throw new NotImplementedException();
            };
        }
    }
}
