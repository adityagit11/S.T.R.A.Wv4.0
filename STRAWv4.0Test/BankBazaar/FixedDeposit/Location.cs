using System;
using System.Speech.Synthesis;
using OpenQA.Selenium;
using SpeechToTextEngine;

namespace STRAWv4._0Test.BankBazaar.FixedDeposit
{
    class Location
    {
        public static void run(RecognitionEngine recogEngine, SpeechSynthesizer synthEngine, IWebDriver driver)
        {
            //synthEngine.Speak("where do you live");

            reiterateIfStaticCommand:

            string command = recogEngine.GetRecognizedText(synthEngine);

            bool WhetherStaticCommand = StaticCommands.WhetherExecuted(driver, command);

            if (!WhetherStaticCommand)
            {
                switch (command)
                {
                    case "banglore":
                        driver.FindElement(By.ClassName("ResidentCity_iconBangalore_21hQE")).Click();
                        CompanyName.run(recogEngine, synthEngine, driver);
                        break;
                    case "chennai":
                        driver.FindElement(By.ClassName("ResidentCity_iconChennai_SfqFL")).Click();
                        CompanyName.run(recogEngine, synthEngine, driver);
                        break;
                    case "mumbai":
                        driver.FindElement(By.ClassName("ResidentCity_iconMumbai_3i73_")).Click();
                        CompanyName.run(recogEngine, synthEngine, driver);
                        break;
                    case "new delhi":
                        driver.FindElement(By.ClassName("ResidentCity_iconNewDelhi_2IARH")).Click();
                        CompanyName.run(recogEngine, synthEngine, driver);
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
