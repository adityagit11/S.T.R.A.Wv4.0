using System;
using System.Speech.Synthesis;
using OpenQA.Selenium;
using SpeechToTextEngine;

namespace STRAWv4._0Test.Youtube
{
    class HomePageClass
    {
        public static void run(RecognitionEngine recogEngine, SpeechSynthesizer synthEngine, IWebDriver driver)
        {
            string command = null;
            while(command!="terminate program")
            {
                command = recogEngine.GetRecognizedText(synthEngine);
                synthEngine.Speak("You have said " + command);
                Console.WriteLine(command);
            }
        }
    }
}
