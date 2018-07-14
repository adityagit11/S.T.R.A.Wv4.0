using System;
using System.Speech.Synthesis;
using OpenQA.Selenium;
using SpeechToTextEngine;

namespace STRAWv4._0Test.BankBazaar.FixedDeposit
{
    class FreeOffers
    {
        public static void run(RecognitionEngine recogEngine, SpeechSynthesizer synthEngine, IWebDriver driver)
        {
            //synthEngine.Speak("entering your details");
            
            string command = recogEngine.GetRecognizedText(synthEngine);
            StaticCommands.WhetherExecuted(driver, command);
            
            if(command=="enter details")
            {
                driver.FindElement(By.CssSelector("input[name=firstName]")).SendKeys("Aditya Singh");
                driver.FindElement(By.CssSelector("input[name=mobileNumber]")).SendKeys("7769987541");
                driver.FindElement(By.CssSelector("input[name=email]")).SendKeys("adityasingh@gmail.com");
                driver.FindElement(By.ClassName("btn-large")).Click();
            }

            string command2 = recogEngine.GetRecognizedText(synthEngine);
            StaticCommands.WhetherExecuted(driver, command2);
        }
    }
}
