using Microsoft.VisualStudio.TestPlatform.Utilities;
using OpenQA.Selenium.Appium;
using System.Diagnostics;

namespace TestUAT.Support
{
    public static class ExtensionMethods
    {
        public static void SetDefaultAndroidOptions(this AppiumOptions options)
        {
            options.PlatformName = "Android";
            options.App = @"C:\git\GitHub\WiseTechGlobal\Glow\Mobility\Android\GlowClient\app\build\outputs\apk\debug\app-debug.apk";
            options.AutomationName = "UiAutomator2";
            options.AddAdditionalAppiumOption("optionalIntentArguments", "-e settings \"{&quot;url&quot;:&quot;https://www-hyetip.cargowise.com/Portals/WRF&quot;,&quot;selectedWarehouseRF&quot;:&quot;true&quot;,&quot;selectedProductWarehouse&quot;:&quot;true&quot;,&quot;selectedTransitWarehouse&quot;:&quot;true&quot;,&quot;selectedPortTransport&quot;:&quot;true&quot;,&quot;enableMultipleAppFeature&quot;:&quot;true&quot;,&quot;mobileServiceUri&quot;:&quot;https://www-hyetip.cargowise.com/Portals/WRF&quot;}\"");
            options.AddAdditionalAppiumOption("appPackage", "com.wisetechglobal.glowclient");
            options.AddAdditionalAppiumOption("appActivity", "com.wisetechglobal.glowclient.FullscreenWebActivity");
            options.AddAdditionalAppiumOption("appium:autoGrantPermissions", true);
        }
    }
}
