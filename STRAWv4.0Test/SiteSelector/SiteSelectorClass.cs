using System;
using System.Speech.Synthesis;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SpeechToTextEngine;
using STRAWv4._0Test.BankBazaar;

namespace STRAWv4._0Test.SiteSelector
{
    class SiteSelectorClass
    {
        public static void Main(string[] args)
        {
            // Initialize RecognitionEngine
            RecognitionEngine recogEngine = new RecognitionEngine();
            recogEngine.SetupRecognitionEngine();

            // Initialize SpeechSynthesizer
            SpeechSynthesizer synthEngine = new SpeechSynthesizer();
            synthEngine.SetOutputToDefaultAudioDevice();

            // Initialize FirefoxDriver
            string GeckoDriverPath = @"C:\Users\adity\source\repos\SpeechRecogTest\geckodriver-v0.21.0-win64";
            IWebDriver driver = new FirefoxDriver(GeckoDriverPath);

            /*
            string recognizedText = recogEngine.GetRecognizedText(synthEngine);
            synthEngine.Speak("You have said " + recognizedText + "which I have successfully detected");
            */

            BankBazaar.HomePageClass.run(recogEngine, synthEngine, driver);
            //Youtube.HomePageClass.run(recogEngine, synthEngine, driver);

            driver.Close();
            driver.Quit();
        }
    }
}
