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
    public class Android11 : IEmulator
    {
        public string Udid = "";
        public readonly string avdName = "Android11";
        private bool IsEmulatorRunning = false;

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
                options.DeviceName = "Android 11 Emulator";
                options.AddAdditionalAppiumOption("udid", Udid);
                options.AddAdditionalAppiumOption("chromedriverExecutable", @"C:\chromedriverv83\chromedriver.exe");
                return options;
            }
        }

        public AppiumLocalService Service
        {
            get
            {
                var services = new AppiumServiceBuilder()
                    .UsingAnyFreePort()
                    .WithLogFile(new FileInfo("appium.log"))
                    .Build();

                services.Start();
                return services;
            }
        }

        public void StartEmulator()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts", "LaunchEmulators.ps1");
            CommandHelper.RunLaunchEmulatorPowershellScript(path, avdName);
            IsEmulatorRunning = true;
        }

        public AppiumDriver StartDriver()
        {
            if (!IsEmulatorRunning)
            {
                StartEmulator();
            }
            Udid = SetupHelper.PopulateUDID(avdName);
            AndroidDriver driver = new AndroidDriver(Service.ServiceUrl, AppiumOptions);
            Driver = driver;

            return driver;
        }
    }
}
