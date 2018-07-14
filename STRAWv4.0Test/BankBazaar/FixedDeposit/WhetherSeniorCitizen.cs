using System;
using System.Speech.Synthesis;
using OpenQA.Selenium;
using SpeechToTextEngine;

namespace STRAWv4._0Test.BankBazaar.FixedDeposit
{
    class WhetherSeniorCitizen
    {
        public static void run(RecognitionEngine recogEngine, SpeechSynthesizer synthEngine, IWebDriver driver)
        {
            //synthEngine.Speak("are you a senior citizen");

            reiterateIfStaticCommand:

            string command = recogEngine.GetRecognizedText(synthEngine);

            bool WhetherStaticCommand = StaticCommands.WhetherExecuted(driver, command);

            if (!WhetherStaticCommand)
            {
                switch (command)
                {
                    case "yes":
                        driver.FindElement(By.ClassName("YesNo_iconMaleSeniorCitizenYes_1b5Xa")).Click();
                        FreeOffers.run(recogEngine, synthEngine, driver);
                        break;
                    case "no":
                        driver.FindElement(By.ClassName("YesNo_iconMaleSeniorCitizenNo_AjA0z")).Click();
                        FreeOffers.run(recogEngine, synthEngine, driver);
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
