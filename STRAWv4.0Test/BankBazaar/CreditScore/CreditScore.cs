using System;
using System.Speech.Synthesis;
using OpenQA.Selenium;
using SpeechToTextEngine;

namespace STRAWv4._0Test.BankBazaar.CreditScore
{
    class CreditScore
    {
        public static void run(RecognitionEngine recogEngine, SpeechSynthesizer synthEngine, IWebDriver driver)
        {
            //recogEngine.UnSetAllGrammarFiles();
            //recogEngine.SetAnotherGrammarFile("CreditScore.txt");

            reiterateIfStaticCommand:

            string command = recogEngine.GetRecognizedText(synthEngine);

            bool WhetherStaticCommand = StaticCommands.WhetherExecuted(driver, command);

            if (!WhetherStaticCommand)
            {
                Console.WriteLine(command);
            
                /*
                switch (command)
                {
            
                    default:
                        break;
                }
                */
            }
            else
                goto reiterateIfStaticCommand;
        }
    }
}
