using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10395938_PROG6221_POEPart1
{
    public class TextGreeting
    {
        // The TextGreeting class handles user interaction and displays a greeting with the user's name.
        // The AskUserName method prompts the user to input their name and ensures valid input.

        public static string AskUserName()
        {
            string userName = "";

            // Infinite loop to keep asking for the user's name until valid input is received.
            while (true)
            {

                // Prompting the user to input their name.
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n" + new string('-', 50));
                Console.WriteLine("Let's get to know you!");
                Console.Write("Please enter your name: ");
                
                Console.ResetColor();
                try
                {
                    userName = Console.ReadLine();
                    
                    // Checking if the input is empty or contains only whitespace.
                    if (string.IsNullOrWhiteSpace(userName))
                    {
                        // Throwing an exception if the input is invalid (empty or whitespace).
                        throw new ArgumentException("Name cannot be empty.");
                    }

                    // Displaying a welcome message with the user's name in a formatted box.
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n╔══════════════════════════════════════════════╗");
                    Console.WriteLine($"║  Welcome, {userName}! Your Cyber Buddy is here.  ");
                    Console.WriteLine($"╚══════════════════════════════════════════════╝");
                    Console.ResetColor();
                    Console.WriteLine("Type something like 'password tips', 'safe browsing', or type 'exit' to quit.");
                    break;
                }

                catch (Exception ex)
                {
                    // If an exception is thrown (invalid input), display an error message in red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Input error: {ex.Message}");
                    Console.ResetColor();
                }
            }

            // Returning the valid user name entered by the user.
            return userName;
        }

    }
}
