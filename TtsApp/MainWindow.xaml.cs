using System.Linq;
using System.Windows;
using System.Speech.Synthesis;

namespace TtsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SpeechSynthesizer _reader;
        const string voiceName = "Microsoft David Desktop";

        public MainWindow()
        {
            InitializeComponent();

            _reader = new SpeechSynthesizer();

            var voiceInstalled = _reader.GetInstalledVoices()
                                     .FirstOrDefault(x => x.VoiceInfo.Description.Contains(voiceName)) != null;

            if (!voiceInstalled)
            {
                MessageBox.Show($"Voice '{voiceName}' is not installed in system. Now we exit");
            }

            _reader.SelectVoice(voiceName);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _reader.Speak(TextToSpeakBox.Text);
        }
    }
}
