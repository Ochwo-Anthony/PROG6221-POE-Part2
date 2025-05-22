using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10395938_PROG6221_POEPart1
{
    // The AsciiArt class inherits from the GreetingBase class.
    internal class AsciiArt : GreetingBase
    {
        public override void PlayGreeting()
        {
            // Set the console text color to green to highlight the ASCII art.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"

       _..._                                                                 .-'''-.           
    .-'_..._''.                                                             '   _    \         
  .' .'      '.\           /|              __.....__             /|       /   /` '.   \        
 / .'       .-.          .-||          .-''         '.           ||      .   |     \  '        
. '          \ \        / /||         /     .-''""'-.  `. .-,.--. ||      |   '      |  '  .|   
| |           \ \      / / ||  __    /     /________\   \|  .-. |||  __  \    \     / / .' |_  
| |            \ \    / /  ||/'__ '. |                  || |  | |||/'__ '.`.   ` ..' /.'     | 
. '             \ \  / /   |:/`  '. '\    .-------------'| |  | ||:/`  '. '  '-...-'`'--.  .-' 
 \ '.          . \ `  /    ||     | | \    '-.____...---.| |  '- ||     | |             |  |   
  '. `._____.-'/  \  /     ||\    / '  `.             .' | |     ||\    / '             |  |   
    `-.______ /   / /      |/\'..' /     `''-...... -'   | |     |/\'..' /              |  '.' 
             `|`-' /       '  `'-'`                      |_|     '  `'-'`               |   /  
               '..'                                                                     `'-'   

");
            // Reset the console text color to default after the ASCII art.
            Console.ResetColor();
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("                     A Cyber Security Chatbot");
            Console.ResetColor();
        }
    }
}
