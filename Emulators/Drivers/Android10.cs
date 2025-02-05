using TestUAT.Emulators.Interfaces;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using TestUAT.Support;

namespace TestUAT.Emulators.Drivers
{
    public class Android10 : IEmulator
    {
        public readonly string Udid = "emulator-5554";

        public AndroidDriver Driver
        {
            get; set;
        }

        public AppiumOptions AppiumOptions
        {
            get
            {
                AppiumOptions options = new AppiumOptions();
                options.SetDefaultAndroidOptions();
                options.AddAdditionalAppiumOption("deviceName", "Android 10 Emulator");
                options.AddAdditionalAppiumOption("udid", Udid);
                return options;
            }
        }
        public AppiumLocalService Service
        {
            get
            {
                return new AppiumServiceBuilder()
                    .UsingAnyFreePort()
                    .Build();
            }
        }

        public void StartDriver()
        {
            AndroidDriver driver = new AndroidDriver(Service.ServiceUrl, AppiumOptions);
            Driver = driver;
        }
    }
}
