using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace TestUAT.Emulators.Interfaces
{
    public interface IEmulator
    {
        AndroidDriver Driver { get; set; }
        AppiumOptions AppiumOptions { get; }
        AppiumLocalService Service { get; }
        void StartDriver();
    }
}
