using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace TestUAT.Emulators.Interfaces
{
    public interface IEmulator
    {
        AndroidDriver Driver { get; set; }
        AppiumOptions AppiumOptions { get; }
        AppiumLocalService Service { get; }
        void StartEmulator();
        AppiumDriver StartDriver();
    }
}
