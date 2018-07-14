using OpenQA.Selenium;
using System;

namespace STRAWv4._0Test.BankBazaar
{
    class StaticCommands
    {
        public static bool WhetherExecuted(IWebDriver driver, string command)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

            switch (command)
            {
                case "mouse scroll down":
                    jse.ExecuteScript("window.scrollBy(0,250)", "");
                    return true;
                case "mouse scroll up":
                    jse.ExecuteScript("window.scrollBy(0,-250)", "");
                    return true;
                case "refresh browser":
                    driver.Navigate().Refresh();
                    return true;
                case "terminate program":
                    driver.Close();
                    driver.Quit();
                    Environment.Exit(0);
                    return true;
                default:
                    break;
            }

            return false;
        }
    }
}
