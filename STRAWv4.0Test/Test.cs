using SpeechToTextEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace STRAWv4._0Test
{
    class Test
    {
        public static void Main(string[] args)
        {
            // Initialize RecognitionEngine
            RecognitionEngine recogEngine = new RecognitionEngine();
            recogEngine.SetupRecognitionEngine();
            recogEngine.SetGrammarFile("Numbers.txt");

            // Initialize SpeechSynthesizer
            SpeechSynthesizer synthEngine = new SpeechSynthesizer();
            synthEngine.SetOutputToDefaultAudioDevice();

            string command = recogEngine.GetRecognizedText(synthEngine);
            Console.WriteLine(command);

        }
    }
}
