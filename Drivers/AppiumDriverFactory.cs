using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;

namespace TestUAT.Drivers
{
    public static class AppiumDriverFactory
    {
        public static AppiumDriver CreateDriver(string platform)
        {
            var options = new AppiumOptions();

            if (platform == "android")
            {
                options.PlatformName = "Android";
                options.DeviceName = "23010522512714";
                options.App = "C:\\Users\\Mitchell.Plass\\OneDrive - WiseTech Global Pty Ltd\\Desktop\\Mobility\\AppiumTest.apk";
                options.AutomationName = "UiAutomator2";
                return new AndroidDriver(new Uri("http://10.61.209.35:4723"), options);
            }
            else if (platform == "ios")
            {
                //do something similar but with an iOS driver (random data)
                options.PlatformName = "iOS";
                options.DeviceName = "iPhone Simulator";
                options.App = "/path/to/your/app.app";
                options.AutomationName = "XCUITest";
                return new IOSDriver(new Uri("http://10.61.209.35:4723"), options);
            }
            else
            {
                throw new NotSupportedException($"Unsupported platform: {platform}");
            }
        }
    }
}
