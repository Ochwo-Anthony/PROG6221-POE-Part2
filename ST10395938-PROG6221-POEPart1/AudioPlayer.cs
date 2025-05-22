using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media; // Required for working with sound files


namespace ST10395938_PROG6221_POEPart1
{
    // The AudioPlayer class inherits from GreetingBase, and it is responsible for playing an audio greeting.
    internal class AudioPlayer : GreetingBase
    {
        // Override the PlayGreeting method from the GreetingBase class.
        public override void PlayGreeting()
        {
            // Construct the file path for the audio file (AudioGreeting.wav) located in the Resources folder.
            // AppDomain.CurrentDomain.BaseDirectory gets the path of the application's current directory.
            string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "AudioGreeting.wav");

            try
            {
                // Create a SoundPlayer object with the specified audio file path.
                SoundPlayer player = new SoundPlayer(audioPath);
                // Play the audio file synchronously (blocking call).
                player.PlaySync();
            }
            catch (Exception ex)
            {
                // If an error occurs during audio playback, print an error message in red text.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Audio Error: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
