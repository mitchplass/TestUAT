using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;

namespace TestUAT.Drivers
{
    public static class AppiumDriverFactory
    {
        public static AppiumDriver CreateDriver(string platform, string deviceName, string port)
        {
            var options = new AppiumOptions();

            if (platform == "android")
            {
                options.PlatformName = "Android";
                options.App = "C:\\git\\wtg\\Glow\\Glow\\Mobility\\Android\\GlowClient\\app\\build\\outputs\\apk\\debug\\app-debug.apk";
                options.AutomationName = "UiAutomator2";
                options.AddAdditionalAppiumOption("udid", deviceName);
                options.AddAdditionalAppiumOption("optionalIntentArguments", "-e settings \"{&quot;url&quot;:&quot;https://www-hyetip.cargowise.com/Portals/WRF&quot;,&quot;selectedWarehouseRF&quot;:&quot;true&quot;,&quot;selectedProductWarehouse&quot;:&quot;true&quot;,&quot;selectedTransitWarehouse&quot;:&quot;true&quot;,&quot;selectedPortTransport&quot;:&quot;true&quot;,&quot;enableMultipleAppFeature&quot;:&quot;true&quot;,&quot;mobileServiceUri&quot;:&quot;https://www-hyetip.cargowise.com/Portals/WRF&quot;}\"");
                options.AddAdditionalAppiumOption("appPackage", "com.wisetechglobal.glowclient");
                options.AddAdditionalAppiumOption("appActivity", "com.wisetechglobal.glowclient.FullscreenWebActivity");
                options.AddAdditionalAppiumOption("appWaitActivity", "com.wisetechglobal.glowclient.activities.SplashScreenActivity,com.wisetechglobal.glowclient.FullscreenWebActivity,com.wisetechglobal.activities.MainActivity");
                options.AddAdditionalAppiumOption("appium:autoGrantPermissions", true);
                return new AndroidDriver(new Uri($"http://127.0.0.1:{port}"), options);
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
