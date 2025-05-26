using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10395938_PROG6221_POEPart1
{
    internal class ResponseSystem
    {
        // Tracks the user's favorite (most frequently asked) topic
        private static string favoriteTopic = "";

        // Stores how many times each topic has been asked about
        private static Dictionary<string, int> topicCounts = new Dictionary<string, int>();

        // Counter for the number of messages exchanged
        private static int messageCount = 0;

        // Number of interactions before suggesting a proactive tip
        private static int proactivePromptThreshold = 5;

        // Last topic the chatbot responded to
        private static string lastTopicAnswered = "";

        // Keeps track of which tips have already been shown for the current topic
        private static HashSet<int> usedTipIndexes = new HashSet<int>();

        // Stores the current detected mood of the user
        private static string currentMood = "";

        // Keywords/phrases that trigger a "tell me more" type response
        private static readonly string[] moreInfoTriggers = new string[]
        {
            "anything else", "more info", "tell me more",
            "more information", "what else", "can you elaborate"
        };

        // Random generator for selecting random responses
        private static Random rand = new Random();

        // Core dictionary mapping each topic to a list of potential responses
        private static readonly Dictionary<string, string[]> topicResponses = new Dictionary<string, string[]>
        {
            ["password"] = new string[]
            {
                "Use strong passwords with a mix of letters, numbers, and symbols.",
                "Avoid reusing the same password across multiple sites.",
                "Consider using a trusted password manager.",
                "Don't include personal info like your birthday in your passwords."
            },
            ["phishing"] = new string[]
            {
                "Phishing is a scam to steal your info. Don’t click suspicious links.",
                "Be cautious of emails asking for personal data.",
                "Check the sender's email address for authenticity.",
                "Never give out login details via email."
            },
            ["privacy"] = new string[]
            {
                "Lock down your social media privacy settings.",
                "Avoid posting personal details publicly.",
                "Regularly review app permissions.",
                "Don’t overshare personal moments online."
            },
            ["2fa"] = new string[]
            {
                "2FA adds an extra layer of protection to your accounts.",
                "Even with your password stolen, 2FA keeps hackers out.",
                "Use apps like Google Authenticator for 2FA."
            },
            ["safe browsing"] = new string[]
            {
                "Use browsers that support secure connections.",
                "Avoid clicking on pop-ups or unknown ads.",
                "Look for 'https://' in the web address."
            },
            ["antivirus"] = new string[]
            {
                "Firewalls help block unauthorized access to your computer.",
                "Keep your antivirus software up-to-date.",
                "Run regular scans to check for malware."
            },
            ["cloud"] = new string[]
            {
                "Enable 2FA on your cloud accounts.",
                "Don’t store sensitive info in unencrypted form.",
                "Choose trusted cloud providers."
            }
        };

        // Responses that reflect the user's mood
        private static readonly Dictionary<string, string> sentimentResponses = new Dictionary<string, string>()
        {
            ["worried"] = "It's completely understandable to feel that way. Scammers can be very convincing. Let me share some tips to help you stay safe.",
            ["curious"] = "That's great! Curiosity is the first step to staying safe online. Let me provide some useful info.",
            ["frustrated"] = "I know cybersecurity can feel overwhelming at times. I'm here to help make it simpler for you."
        };

        // Entry point for the chatbot conversation
        public static void StartInteraction(string userName)
        {
            while (true)
            {
                // Prompt user for input
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nAsk me something: ");
                Console.ResetColor();

                string userInput = Console.ReadLine()?.Trim().ToLower();
                messageCount++;

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Please ask a question, {userName}. I did not detect any input!");
                    Console.ResetColor();
                    continue;
                }

                if (userInput == "exit")
                {
                    // Exit message with ASCII art
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(new string('*', 80));
                    Console.WriteLine(@"
            .-'''-.        .-'''-.                                                         
           '   _    \     '   _    \ _______                                              
         /   / '.   \  /   / '.   \\  ___ '.   /|                       __.....__         
  .--./).   |     \  ' .   |     \  ' ' |--.\  \  ||    .-.         .- .-''         '.    
 /.''\\ |   '      |  '|   '      |  '| |    \  ' ||     \ \       / //     .-''""'-.  .  
| |  | |\    \     / / \    \     / / | |     |  '||  __  \ \     / //     /________\   \ 
 \-' /  .    ..' /   .    ..' /  | |     |  |||/'__ '.\ \   / / |                  |      
 /(""'      '-...-'       '-...-'   | |     ' .'|:/  '. '\ \ / /  \    .-------------'     
 \ '---.                              | |___.' /' ||     | |  \_/     \    '-.____...---.  
  /'""""'.\                            /_______.'/  ||\    / '| |       .             .'   
 ||     ||                           \_______|/   |/\'..' /   | |      ''-...... -'        
 \'. __//                                         '  '-'    | |                            
  '---'                                                                                   
");
                    Console.WriteLine("\nThank you, " + userName + "! Stay safe online.");
                    Console.WriteLine(new string('*', 80));
                    Console.ResetColor();
                    break;
                }

                // Generate a response based on user input
                string response = GetResponse(userInput, userName);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(response);
                Console.ResetColor();

                // Proactively remind user about their favorite topic
                if (messageCount % proactivePromptThreshold == 0 && !string.IsNullOrEmpty(favoriteTopic))
                {
                    string[] tips = GetResponsesByTopic(favoriteTopic);
                    if (tips.Length > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nAs a quick reminder based on your interest in {favoriteTopic}:\n{tips[rand.Next(tips.Length)]}");
                        Console.ResetColor();
                    }
                }
            }
        }

        // Main logic for deciding what response to return
        private static string GetResponse(string input, string userName)
        {
            // Mood detection: if user mentions "worried", "curious", or "frustrated"
            foreach (var sentiment in sentimentResponses.Keys)
            {
                if (input.Contains(sentiment))
                {
                    currentMood = sentiment;
                    return sentimentResponses[sentiment];
                }
            }

            // Check for follow-up prompts like "tell me more"
            if (moreInfoTriggers.Any(trigger => input.Contains(trigger)) && !string.IsNullOrEmpty(lastTopicAnswered))
            {
                var tips = topicResponses[lastTopicAnswered];
                if (tips != null && tips.Length > 0)
                {
                    var availableIndexes = Enumerable.Range(0, tips.Length)
                        .Where(i => !usedTipIndexes.Contains(i)).ToList();

                    if (availableIndexes.Count == 0)
                    {
                        usedTipIndexes.Clear();
                        availableIndexes = Enumerable.Range(0, tips.Length).ToList();
                    }

                    int selectedIndex = availableIndexes[rand.Next(availableIndexes.Count)];
                    usedTipIndexes.Add(selectedIndex);
                    return AdaptResponseToMood(tips[selectedIndex], currentMood);
                }
                else
                {
                    return $"I've shared all I know about {lastTopicAnswered}, but feel free to ask about other topics!";
                }
            }

            // Built-in responses for common greetings/questions
            if (input.Contains("how are you"))
                return $"I'm doing well, {userName}! Ready to help you stay secure online.";

            if (input.Contains("your purpose"))
                return "I'm your cybersecurity buddy — here to educate and protect you online.";

            if (input.Contains("what can i ask") || input.Contains("help"))
                return "You can ask me about:\n- Password safety\n- Phishing attacks\n- 2FA (Two-Factor Authentication)\n- Social media privacy\n- Safe browsing habits\n- Antivirus and firewalls";

            // Try to match input to a cybersecurity topic
            foreach (var topic in topicResponses.Keys)
            {
                if (input.Contains(topic))
                {
                    UpdateTopicCount(topic);
                    lastTopicAnswered = topic;
                    usedTipIndexes.Clear();

                    currentMood = "";

                    var responses = topicResponses[topic];
                    string selectedResponse = responses[rand.Next(responses.Length)];

                    return AdaptResponseToMood(selectedResponse, currentMood);
                }
            }

            // Capture interest statements
            if (input.Contains("i'm interested in"))
            {
                string[] words = input.Split(' ');
                string interest = words.Last();
                UpdateTopicCount(interest);
                return $"Great! I'll remember that you're interested in {interest}. It's a crucial part of staying safe online.";
            }

            // Fallback if no match is found
            string[] fallbackResponses = {
                $"Hmm, I'm not sure about that, {userName}. Try asking something like 'What is phishing?'",
                $"That's an interesting question! I'll try to learn more about that.",
                $"Cybersecurity is broad! Try narrowing your question to passwords, scams, or privacy.",
                $"I may need an update to answer that — try asking about 2FA, antivirus, or phishing."
            };

            return fallbackResponses[rand.Next(fallbackResponses.Length)];
        }

        // Tracks topic frequency and updates favorite topic
        private static void UpdateTopicCount(string topic)
        {
            if (topicCounts.ContainsKey(topic))
                topicCounts[topic]++;
            else
                topicCounts[topic] = 1;

            favoriteTopic = topicCounts.OrderByDescending(kv => kv.Value).First().Key;
        }

        // Gets all responses associated with a topic
        private static string[] GetResponsesByTopic(string topic)
        {
            return topicResponses.ContainsKey(topic) ? topicResponses[topic] : new string[0];
        }

        // Adapts a response based on the current mood
        private static string AdaptResponseToMood(string baseResponse, string mood)
        {
            switch (mood)
            {
                case "worried":
                    return $"{baseResponse} Don't worry — you're not alone in this. These steps can really help protect you.";
                case "curious":
                    return $"{baseResponse} There's so much more to learn — you're on the right track exploring this topic!";
                case "frustrated":
                    return $"{baseResponse} It can feel complicated, but you're making progress. I'm here to guide you.";
                default:
                    return baseResponse;
            }
        }

    }

}
