using System;
using System.Speech.Synthesis;
using OpenQA.Selenium;
using SpeechToTextEngine;

namespace STRAWv4._0Test.BankBazaar.FixedDeposit
{
    class CompanyName
    {
        public static void run(RecognitionEngine recogEngine, SpeechSynthesizer synthEngine, IWebDriver driver)
        {
            //synthEngine.Speak("which company do you work for");

            reiterateIfStaticCommand:

            string command = recogEngine.GetRecognizedText(synthEngine);

            bool WhetherStaticCommand = StaticCommands.WhetherExecuted(driver, command);

            if (!WhetherStaticCommand)
            {
                switch (command)
                {
                    case "microsoft":
                        driver.FindElement(By.ClassName("react-autosuggest__input")).SendKeys("microsoft");
                        driver.FindElement(By.ClassName("btn-large")).Click();
                        Salary.run(recogEngine, synthEngine, driver);
                        break;
                    case "google":
                        driver.FindElement(By.ClassName("react-autosuggest__input")).SendKeys("google");
                        driver.FindElement(By.ClassName("btn-large")).Click();
                        Salary.run(recogEngine, synthEngine, driver);
                        break;
                    case "facebook":
                        driver.FindElement(By.ClassName("react-autosuggest__input")).SendKeys("facebook");
                        driver.FindElement(By.ClassName("btn-large")).Click();
                        Salary.run(recogEngine, synthEngine, driver);
                        break;
                    case "twitter":
                        driver.FindElement(By.ClassName("react-autosuggest__input")).SendKeys("twitter");
                        driver.FindElement(By.ClassName("btn-large")).Click();
                        Salary.run(recogEngine, synthEngine, driver);
                        break;
                    default:
                        break;
                }
            }
            else
                goto reiterateIfStaticCommand;
        }
    }
}
