using System;
using System.Speech.Synthesis;
using OpenQA.Selenium;
using SpeechToTextEngine;

namespace STRAWv4._0Test.BankBazaar.FixedDeposit
{
    class FixedDeposit
    {
        public static void run(RecognitionEngine recogEngine, SpeechSynthesizer synthEngine, IWebDriver driver)
        {
            //synthEngine.SpeakAsync("choose from compare fixed deposit, get a rate, fixed deposit reviews" +
            //     "hungry for more");

            reiterateIfStaticCommand:

            string command = recogEngine.GetRecognizedText(synthEngine);

            bool WhetherStaticCommand = StaticCommands.WhetherExecuted(driver, command);

            if (!WhetherStaticCommand)
            {
                switch (command)
                {
                    case "submit my fixed deposit":
                        driver.FindElement(By.ClassName("custom-quote")).Click();
                        Location.run(recogEngine, synthEngine, driver);
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
