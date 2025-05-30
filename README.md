# PROG6221-POE-Part2


Project Name: Cybersecurity Awareness Bot

Project Description:
The Cybersecurity Awareness Bot is a C# console application designed to educate users about cybersecurity topics. It utilizes a friendly chatbot interface where users can interact with the bot to ask questions related to topics like password safety, phishing, and safe browsing.

GITHUB LINK:
https://github.com/Ochwo-Anthony/PROG6221-POE-Part2

Project Structure:
The project has the following structure:

- .github/workflows/
  - main.yml: The CI/CD pipeline configuration for GitHub Actions.

- ST10395938-PROG6221-POEPart1/
  - Resources/
    - AudioGreeting.wav: Audio file for the greeting sound.
  - bin/Debug/net9.0/: The compiled binaries for the application.
  - obj/: Temporary object files during compilation.
  - AsciiArt.cs: Abstract class Contains ASCII art logic for the bot’s greeting.
  - AudioPlayer.cs: Abstract class Manages audio greetings.
  - GreetingBase.cs: Base class for greeting functionality (both audio and text).
  - Program.cs: Main entry point of the application.
  - ResponseSystem.cs: Contains the logic for user interaction and response generation.
  - ST10395938-PROG6221-POEPart1.csproj: Project file for building the solution.
  - ST10395938-PROG6221-POEPart1.sln: Solution file.
  - TextGreeting.cs: Contains logic for text-based greeting and name input.

Prerequisites:
Before running the application, ensure that you have the following:

- .NET SDK (version 9 or later) installed on your machine.
  - You can download it from: https://dotnet.microsoft.com/download
- GitHub account for accessing the project repository and running CI/CD pipelines.

Setup and Installation:
1. Clone the repository:
   git clone https://github.com/Ochwo-Anthony/PROG6221-POE-Part2.git

2. Navigate to the project directory:
   cd ST10395938-PROg6221-POEPart1

3. Restore the dependencies (if any) by running:
   dotnet restore

4. To build the project, run:
   dotnet build

5. To run the application, use the following command:
   dotnet run

6. The application will prompt for the user’s name and provide a greeting. Afterward, you can start interacting with the bot.

Usage:
1. Upon running the application, you will be greeted with an ASCII art and audio greeting.
2. The bot will ask for your name.
3. Once your name is provided, the bot will allow you to ask questions about cybersecurity.
4. The bot will answer questions such as:
   - "How are you?"
   - "What is your purpose?"
   - "What can I ask?"
   - "Password safety"
   - "Phishing"
   - "Safe browsing"
5. You can type "exit" to terminate the conversation.

CI/CD Pipeline:
This project is integrated with GitHub Actions for Continuous Integration/Continuous Deployment (CI/CD). The configuration is in the .github/workflows/main.yml file. Upon pushing changes to the repository, the workflow automatically builds and tests the project.

Release Notes

v1.1.0 — 2025-05-26:
New Features & Enhancements

Sentiment Detection & Empathy

- Added advanced sentiment detection to recognize emotional tones like worried, curious, and frustrated.
- The chatbot now provides tailored, empathetic responses based on the detected mood to improve user experience.

Dynamic Conversation Flow

- Introduced support for contextual follow-ups using triggers like "more info" or "anything else", allowing users to explore topics in depth.
- Sentiment-based responses are automatically cleared when a new topic is detected, ensuring relevant tone adaptation.

Personalized Interaction

- Tracks favorite topics based on user queries and delivers proactive tips after every few messages to reinforce learning.

Structured & Maintainable Design

- Refactored response handling using dictionaries and modular functions for better scalability and easier maintenance.

Intelligent Proactive Prompts

- Periodically provides helpful tips tailored to the user’s most engaged topic to encourage safer online habits.

Input Validation & Robust Handling

- Improved user input checks to prevent empty questions and handle unrecognized input gracefully with friendly fallback suggestions.

v1.0.0 — 2025-04-17:

Initial release of Cybersecurity Awareness Bot.

Basic chatbot features covering password safety, phishing, privacy, and other cybersecurity topics.

Included audio and ASCII art greetings.

Implemented simple user input handling and random response selection.

    REFERENCES & CONTRIBUTIONS
 ----------------------------------------------------------------------------

REFERENCES

Troelsen, A., & Japikse, P. (2022). *Pro C# 10 with .NET 6: Foundational principles and practices in programming* (11th ed.). Apress.

CONTRIBUTIONS

    1. ASCII Art Generator:
        - Source : https://patorjk.com/software/taag
        - Use    : For generating styled welcome ASCII art in the AsciiArt class.

    2. Console Colors and Styling:
        - Concept : https://learn.microsoft.com/en-us/dotnet/api/system.console.foregroundcolor
        - Use    : For improving user interface with color-coded responses and prompts.

    3. Exception Handling and User Input Validation:
        - Tutorials : Microsoft C# Documentation, YouTube (freeCodeCamp C# tutorials)
        - Use    : Try-catch block logic in `TextGreeting` and `ResponseSystem`.

    4. Audio Playback in Console:
        - Idea   : Adapted from community suggestions on StackOverflow:
                  https://stackoverflow.com/questions/221925/playing-audio-file-in-c-sharp
        - Use    : Implemented in `AudioPlayer` class with `System.Media.SoundPlayer`.

    5. Chatbot Conversation Logic:
        - Inspiration : Basic decision tree structure from beginner chatbot models.
        - Use    : Implemented in `ResponseSystem.GetResponse()` using `string.Contains`.

    6. General Formatting Tips & Visual Prompts:
        - Community Snippets & Visual Enhancements: ChatGPT-assisted refinements.
        - Use    : Enhanced user prompts.

Contact:
For more information or to report issues, please contact:
- Author: Anthony Ochwo
- Student Number: ST10395938
- Email: st10395938@imconnect.edu.za
