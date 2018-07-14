using System;
using System.Globalization;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace SpeechToTextEngine
{
    class RecognitionEngine
    {
        private CultureInfo ci_English;
        private SpeechRecognitionEngine recognizer;

        private RecognitionResult recognizedResult;

        public RecognitionEngine()
        {

        }

        // 1. Setup the engine
        public void SetupRecognitionEngine()
        {
            // Initiate the CultureInfo class with "en-US" language model.
            ci_English = new CultureInfo("en-US");

            // Supply the SpeechRecognitionEngine with CultureInfo class's object
            recognizer = new SpeechRecognitionEngine(ci_English);

            // Configure input to the speech recognizer.
            recognizer.SetInputToDefaultAudioDevice();

            // Describe the recogniztion engine
            PrintEngineName();

        }
        private void PrintEngineName()
        {
            foreach (var recognizers in SpeechRecognitionEngine.InstalledRecognizers())
            {
                Console.WriteLine("Starting {0}", recognizers.Description);
            }
        }

        // 2. Load grammar file into engine
        public void SetGrammarFile(string fileName)
        {
            // Load the grammar into recognizer
            string directoryPath = @"C:\Workstation\Ventures\S.T.R.A.Wv4.0\BBGrammarFiles\";
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
        private  bool WhetherConfirmed(SpeechSynthesizer synthEngine)
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
