using System;
using System.Collections.Generic;

namespace ST10395938_PROG6221_POEPart1
{
    internal class ResponseSystem
    {
        private static readonly Dictionary<string, string[]> topicResponses = new Dictionary<string, string[]>
        {
            ["password"] = new[]
            {
                "Use strong passwords with uppercase, lowercase, numbers, and symbols.",
                "Avoid using personal details like your name or birthdate in passwords.",
                "Never reuse passwords across accounts — use a password manager.",
                "Change your passwords regularly, especially after a breach.",
                "Use long, unique phrases instead of single words for better security."
            },
            ["phishing"] = new[]
            {
                "Phishing is a scam to steal your info. Never click suspicious links or give out your login credentials.",
                "Look out for urgent-sounding emails that try to trick you into revealing data.",
                "Always double-check the sender’s email before trusting a message.",
                "Avoid clicking links from unknown sources or downloading unexpected attachments.",
                "Enable spam filters and educate yourself on common phishing techniques."
            },
            ["privacy"] = new[]
            {
                "Don't overshare personal information like your address or phone number online.",
                "Adjust your privacy settings so only trusted people can see your content.",
                "Be cautious with friend requests — not everyone is who they say they are.",
                "Avoid posting your real-time location or travel plans.",
                "Use pseudonyms and private accounts if possible for personal protection."
            },
            ["safe browsing"] = new[]
            {
                "Keep your browser updated to patch known vulnerabilities.",
                "Avoid websites without HTTPS — they’re not secure.",
                "Never download files from untrusted websites.",
                "Use browser extensions that enhance privacy and security.",
                "Enable pop-up blockers and avoid clicking on shady ads."
            },
            ["2fa"] = new[]
            {
                "2FA adds a second layer of protection — use it wherever available.",
                "Even if your password is stolen, 2FA keeps your account secure.",
                "Use an authenticator app instead of SMS for more secure 2FA.",
                "Enable 2FA on social media, email, and banking apps.",
                "2FA makes account breaches significantly harder for attackers."
            },
            ["antivirus"] = new[]
            {
                "Use trusted antivirus software to detect and block malware.",
                "Firewalls protect your system from unauthorized access.",
                "Keep your antivirus up to date to stay protected.",
                "Run full scans periodically, not just real-time monitoring.",
                "Don’t disable your firewall unless absolutely necessary."
            },
            ["cloud"] = new[]
            {
                "Use strong passwords and 2FA for your cloud storage accounts.",
                "Only share files with people you trust — and audit permissions regularly.",
                "Back up critical data locally in case cloud access is lost.",
                "Avoid uploading sensitive documents unless necessary.",
                "Use encryption when storing sensitive files in the cloud."
            }
        };

        public static void StartInteraction(string userName)
        {
            string lastTopic = null;
            string favoriteTopic = null;
            Dictionary<string, int> topicFrequency = new Dictionary<string, int>();
            Random rand = new Random();

            foreach (var topic in topicResponses.Keys)
                topicFrequency[topic] = 0;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nAsk me something: ");
                Console.ResetColor();

                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Please ask a question, {userName}. I did not detect any input!");
                    Console.ResetColor();
                    continue;
                }

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

                string response = GetResponse(userInput, userName, ref lastTopic, ref favoriteTopic, topicFrequency, rand);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(response);
                Console.ResetColor();
            }
        }

        private static string GetResponse(string input, string userName, ref string lastTopic, ref string favoriteTopic, Dictionary<string, int> topicFrequency, Random rand)
        {
            try
            {
                // Handle user-declared favorite topic
                if (input.Contains("i'm interested in") || input.Contains("my favorite topic is"))
                {
                    foreach (var topic in topicResponses.Keys)
                    {
                        if (input.Contains(topic))
                        {
                            favoriteTopic = topic;
                            lastTopic = topic;
                            return $"Great! I'll remember that you're interested in {topic}, {userName}. It's a crucial part of staying safe online.";
                        }
                    }
                }

                // Follow-up continuation
                if ((input.Contains("more") || input.Contains("again") || input.Contains("details") || input.Contains("explain")) && lastTopic != null)
                {
                    if (topicResponses.ContainsKey(lastTopic))
                        return topicResponses[lastTopic][rand.Next(topicResponses[lastTopic].Length)];
                }

                if (input.Contains("how are you"))
                    return $"I'm doing well, {userName}! Ready to help you stay secure online.";

                if (input.Contains("your purpose"))
                    return "I'm your cybersecurity buddy — here to educate and protect you online.";

                if (input.Contains("what can i ask") || input.Contains("help"))
                    return "You can ask me about:\n- Password safety\n- Phishing attacks\n- 2FA (Two-Factor Authentication)\n- Social media privacy\n- Safe browsing habits\n- Antivirus and firewalls";

                foreach (var topic in topicResponses.Keys)
                {
                    if (input.Contains(topic))
                    {
                        lastTopic = topic;
                        topicFrequency[topic]++;

                        // Auto-update favorite topic by frequency
                        string mostFrequent = null;
                        int maxCount = 0;
                        foreach (var pair in topicFrequency)
                        {
                            if (pair.Value > maxCount)
                            {
                                maxCount = pair.Value;
                                mostFrequent = pair.Key;
                            }
                        }

                        if (mostFrequent != null)
                            favoriteTopic = mostFrequent;

                        return topicResponses[topic][rand.Next(topicResponses[topic].Length)];
                    }
                }

                string[] fallbackResponses = {
                    $"Hmm, I'm not sure about that, {userName}. Try asking something like 'What is phishing?' or 'Tips for safe browsing'.",
                    $"Interesting question! I may need an update to answer that one.",
                    $"That's outside my expertise, {userName}. But I'm always learning!",
                    favoriteTopic != null
                        ? $"As someone interested in {favoriteTopic}, you might enjoy learning how to protect yourself in that area."
                        : $"Cybersecurity is broad! Try narrowing your question to something like passwords, scams, or privacy."
                };

                return fallbackResponses[rand.Next(fallbackResponses.Length)];
            }
            catch (Exception ex)
            {
                return $"Oops! Something went wrong: {ex.Message}";
            }
        }
    }
}
