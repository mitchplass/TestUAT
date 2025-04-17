using TestUAT.Emulators.Interfaces;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using TestUAT.Support;
using Base = TestUAT.Hooks.Hooks;

namespace TestUAT.Emulators.Drivers
{
    public class Android10 : IEmulator
    {
        public readonly string Udid = "emulator-5554";
        public readonly string avdName = "Android10";

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
                options.DeviceName = "Android 10 Emulator";
                options.AddAdditionalAppiumOption("udid", Udid);
                options.AddAdditionalAppiumOption("chromedriverExecutable", @"C:\chromedriverv74\chromedriver.exe");
                return options;
            }
        }
        public AppiumLocalService Service
        {
            get
            {
                var services = new AppiumServiceBuilder()
                    .UsingAnyFreePort()
                    .Build();

                services.Start();
                return services;
            }
        }

        public void StartEmulator()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts", "LaunchEmulators.ps1");
            CommandHelper.RunLaunchEmulatorPowershellScript(path, avdName);
            Base.IsEmulatorRunning.Value = true;
        }

        public AppiumDriver StartDriver()
        {
            if (!Base.IsEmulatorRunning.Value)
            {
                StartEmulator();
            }
            AndroidDriver driver = new AndroidDriver(Service.ServiceUrl, AppiumOptions);
            Driver = driver;

            return driver;
        }
    }
}
