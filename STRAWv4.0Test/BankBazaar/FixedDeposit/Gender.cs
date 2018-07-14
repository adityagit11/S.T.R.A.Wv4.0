using System;
using System.Speech.Synthesis;
using OpenQA.Selenium;
using SpeechToTextEngine;

namespace STRAWv4._0Test.BankBazaar.FixedDeposit
{
    class Gender
    {
        public static void run(RecognitionEngine recogEngine, SpeechSynthesizer synthEngine, IWebDriver driver)
        {
            //synthEngine.Speak("what is your gender");

            reiterateIfStaticCommand:

            string command = recogEngine.GetRecognizedText(synthEngine);

            bool WhetherStaticCommand = StaticCommands.WhetherExecuted(driver, command);

            if (!WhetherStaticCommand)
            {
                switch (command)
                {
                    case "male":
                        driver.FindElement(By.ClassName("Gender_iconMale_2uEOT")).Click();
                        WhetherSeniorCitizen.run(recogEngine, synthEngine, driver);
                        break;
                    case "female":
                        driver.FindElement(By.ClassName("Gender_iconFemale_yFfRz")).Click();
                        WhetherSeniorCitizen.run(recogEngine, synthEngine, driver);
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
