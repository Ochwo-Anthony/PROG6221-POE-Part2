namespace ST10395938_PROG6221_POEPart1
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Set the console window title
            Console.Title = "Cybersecurity Awareness ChatBot";

            // Create greeting objects for ASCII art and audio playback
            GreetingBase text = new AsciiArt();
            GreetingBase audio = new AudioPlayer();

            // Play visual (ASCII) and audio greetings
            text.PlayGreeting();
            audio.PlayGreeting();

            // Display welcome message and menu options in a different color
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Welcome to the Cybersecurity Awareness ChatBot ===");
            Console.WriteLine("1. Start Application");
            Console.WriteLine("2. Exit");
            Console.ResetColor();

            bool validChoice = false;

            // Prompt the user until a valid choice is made
            while (!validChoice)
            {
                Console.Write("Please enter your choice (1 or 2): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        validChoice = true;
                        break;

                    case "2":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(new string('*', 80));
                        Console.WriteLine(@"

            .-'''-.        .-'''-.                                                         
           '   _    \     '   _    \ _______                                               
         /   /` '.   \  /   /` '.   \\  ___ `'.   /|                        __.....__      
  .--./).   |     \  ' .   |     \  ' ' |--.\  \  ||    .-.          .- .-''         '.    
 /.''\\ |   '      |  '|   '      |  '| |    \  ' ||     \ \        / //     .-''""'-.  `.  
| |  | |\    \     / / \    \     / / | |     |  '||  __  \ \      / //     /________\   \ 
 \`-' /  `.   ` ..' /   `.   ` ..' /  | |     |  |||/'__ '.\ \    / / |                  | 
 /(""'`      '-...-'`       '-...-'`   | |     ' .'|:/`  '. '\ \  / /  \    .-------------' 
 \ '---.                              | |___.' /' ||     | | \ `  /    \    '-.____...---. 
  /'""""'.\                            /_______.'/  ||\    / '  \  /      `.             .'  
 ||     ||                           \_______|/   |/\'..' /   / /         `''-...... -'    
 \'. __//                                         '  `'-'`|`-' /                           
  `'---'                                                   '..'                            
  
");
                        Console.WriteLine($"          Thank you, Stay safe online!");
                        Console.WriteLine(new string('*', 80));
                        Console.ResetColor();
                        return; // exits the program

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please enter 1 to start or 2 to exit.");
                        Console.ResetColor();
                        break;
                }
            }

            // Ask the user for their name using a static method from TextGreeting
            string userName = TextGreeting.AskUserName();

            // Start the chatbot interaction loop with the user's name
            ResponseSystem.StartInteraction(userName);

            
        }
    }
}
