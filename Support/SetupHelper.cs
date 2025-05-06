using Microsoft.VisualStudio.TestPlatform.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Diagnostics;

namespace TestUAT.Support
{
    public static class SetupHelper
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
            options.AddAdditionalAppiumOption("uiautomator2ServerInstallTimeout", 60000);
            options.AddAdditionalAppiumOption("adbExecTimeout", 60000);
        }

        public static string PopulateUDID(string emulatorName)
        {
            var deviceIds = CommandHelper.RunADBCommand("devices").FormatDeviceIds();

            foreach (var deviceId in deviceIds)
            {
                if (!deviceId.StartsWith("emulator-"))
                {
                    continue;
                }

                var name = CommandHelper.RunADBCommand($"-s {deviceId} emu avd name").Trim();

                if (name != null && name.Contains(emulatorName))
                {
                    return deviceId;
                }
            }

            return "";
        }

        public static List<string> FormatDeviceIds(this string rawIds)
        {
            var deviceIds = new List<string>();

            if (rawIds == null)
                return deviceIds;

            var lines = rawIds.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (line.StartsWith("List of devices attached") || string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0)
                    deviceIds.Add(parts[0]);
            }

            return deviceIds;
        }
    }
}
