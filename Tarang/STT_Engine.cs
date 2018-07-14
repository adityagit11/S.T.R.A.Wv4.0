using System;
using System.Globalization;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Tarang
{
    class STT_Engine
    {
        private SpeechRecognitionEngine recognizer;
        private RecognitionResult recognizedResult;

        public STT_Engine()
        {
            // Empty parameter constructor

            CultureInfo ci_English = new CultureInfo("en-US");
            recognizer = new SpeechRecognitionEngine(ci_English);
            recognizer.SetInputToDefaultAudioDevice();

            // print the started engine configuration
            foreach(var recognizersInPipe in SpeechRecognitionEngine.InstalledRecognizers())
            {
                Console.WriteLine("Starting {0}", recognizersInPipe.Description);
            }
        }

        // Temp filename: HandSpeakRepo.txt
        public void SetGrammarFile(string fileName)
        {
            // Load the grammar into recognizer
            string directoryPath = @"C:\Workstation\Ventures\S.T.R.A.Wv4.0\TarangGrammarFiles";
            string grammarFilePath = directoryPath + fileName;
            string grammarWords = System.IO.File.ReadAllText(grammarFilePath);
            string[] grammarWordsArray = grammarWords.Split('\n');
            Choices grammarChoices = new Choices(grammarWordsArray);
            GrammarBuilder grammarBuilder = new GrammarBuilder(grammarChoices);
            Grammar gram = new Grammar(grammarBuilder);
            recognizer.LoadGrammar(gram);

            // Start asynchronous, continuous speech recognition.
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        public void UnSetAllGrammarFiles()
        {
            recognizer.UnloadAllGrammars();
        }


        public string GetRecognizedText(SpeechSynthesizer synthEngine)
        {
            recognizedResult = null;

            while (WhetherConfirmed(synthEngine) != true)
            {
                recognizer.RecognizeAsyncCancel();
                synthEngine.SpeakAsync("Speak");
                recognizedResult = recognizer.Recognize(TimeSpan.FromSeconds(5));
            }

            return recognizedResult.Text;
            // synthEngine.SpeakAsync("Do you confirm " + recognizedResult.Text);
        }
        private bool WhetherConfirmed(SpeechSynthesizer synthEngine)
        {
            if (recognizedResult != null)
            {
                // recognizer.RecognizeAsyncCancel();
                synthEngine.SpeakAsync("Do you confirm " + recognizedResult.Text);
                RecognitionResult confirmationCommand = recognizer.Recognize(TimeSpan.FromSeconds(5));
                if (confirmationCommand != null && confirmationCommand.Text == "yes please confirm command")
                    return true;
                else if (confirmationCommand != null && confirmationCommand.Text == "no do not confirm")
                    return false;
            }
            return false;
        }
    }
}
