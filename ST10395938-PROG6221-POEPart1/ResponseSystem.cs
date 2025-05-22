using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10395938_PROG6221_POEPart1
{
    // The ResponseSystem class handles user input and provides appropriate responses related to cybersecurity.
    internal class ResponseSystem
    {
        // The StartInteraction method initiates the interaction with the user and continuously accepts input.
        public static void StartInteraction(string userName)
        {
            // Infinite loop to keep the interaction going until the user exits.
            while (true)
            {
                // Displaying the prompt for the user to ask a question in blue text.
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.Write("\nAsk me something: ");
                Console.ResetColor();

                // Reading and trimming the user's input, converting it to lowercase.
                string userInput = Console.ReadLine()?.Trim().ToLower();

                // If the user input is empty or null, prompt them to rephrase.
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Please ask a question, {userName}. I did not detect any input!");
                    Console.ResetColor();
                    continue;
                }

                // If the user types 'exit', exit the program with a thank-you message.
                if (userInput == "exit")
                {
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
                    Console.WriteLine($"          Thank you, {userName}! Stay safe online!");
                    Console.WriteLine(new string('*', 80));
                    Console.ResetColor();
                    break;
                }

                // Getting the appropriate response for the user input.
                string response = GetResponse(userInput, userName);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(response);
                Console.ResetColor();
            }
        }

        // The GetResponse method generates a response based on the user's input.
        private static string GetResponse(string input, string userName)
        {
            try
            {
                // Checking if the input contains certain keywords and providing appropriate responses.
                if (input.Contains("how are you"))
                    return $"I'm doing well, {userName}! Ready to help you stay secure online.";

                else if (input.Contains("your purpose"))
                    return "I'm your cybersecurity buddy — here to educate and protect you online.";

                else if (input.Contains("what can i ask") || input.Contains("help"))
                    return "You can ask me about:\n- Password safety\n- Phishing attacks\n- 2FA (Two-Factor Authentication)\n- Social media privacy\n- Safe browsing habits\n- Antivirus and firewalls";

                else if (input.Contains("password"))
                    return "Use strong passwords with a mix of uppercase, lowercase, numbers, and symbols. Don’t reuse them — try a password manager.";

                else if (input.Contains("phishing"))
                    return "Phishing is a scam to steal your info. Never click suspicious links or give out your login credentials by email.";

                else if (input.Contains("safe browsing"))
                    return "Browse safely by updating your browser regularly and avoiding sketchy websites. Use HTTPS when possible!";

                else if (input.Contains("2fa") || input.Contains("two-factor"))
                    return "2FA adds an extra layer of protection. Even if someone gets your password, they can't log in without the code from your phone.";

                else if (input.Contains("social media"))
                    return "Be cautious! Don’t overshare. Lock down your privacy settings and avoid posting personal details publicly.";

                else if (input.Contains("firewall") || input.Contains("antivirus"))
                    return "A good antivirus and firewall help keep your device secure from malware, viruses, and unauthorized access.";

                else if (input.Contains("cloud"))
                    return "Cloud services are convenient, but always protect your accounts with strong passwords and enable 2FA.";

                // If no match is found, providing a random fallback response.
                string[] fallbackResponses = {
                    $"Hmm, I'm not sure about that, {userName}. Try asking something like 'What is phishing?' or 'Tips for safe browsing'.",
                    $"Interesting question! I may need an update to answer that one",
                    $"That's outside my expertise, {userName}. But I'm always learning!",
                    $"Cybersecurity is broad! Try narrowing your question to something like passwords, scams, or privacy.",
                };

                // Randomly selecting one of the fallback responses.
                Random rand = new Random();
                return fallbackResponses[rand.Next(fallbackResponses.Length)];
            }
            catch (Exception ex)
            {
                // Handling any unexpected errors that occur during response generation.
                return $"Oops! Something went wrong: {ex.Message}";
            }


        }
    }
}
