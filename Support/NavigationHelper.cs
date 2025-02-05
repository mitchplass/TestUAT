using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUAT.Support
{
    public static class NavigationHelper
    {
        public static void ElementWaitAndClick(By by, WebDriverWait wait)
        {
            var element = wait.Until(driver =>
            {
                var el = driver.FindElement(by);
                return el.Displayed && el.Enabled ? el : null;
            });
            element.Click();
        }

        public static void ElementWaitAndSendKeys(By by, string text, WebDriverWait wait)
        {
            var element = wait.Until(driver =>
            {
                var el = driver.FindElement(by);
                return el.Displayed ? el : null;
            });
            element.SendKeys(text);
        }

        public static IWebElement WaitForElement(By by, WebDriverWait wait)
        {
            return wait.Until(driver =>
            {
                var el = driver.FindElement(by);
                return el.Displayed ? el : null;
            });
        }
    }
}
