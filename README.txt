
Description  
-----------
This is a simple console-based chatbot built in C# that helps users learn about basic cybersecurity concepts. It interacts with users by providing helpful information about password safety, phishing, and safe browsing. The program also optionally plays a voice greeting and displays ASCII art when it starts.

Files  
-----
- chatbot.cs        - Contains the chatbot logic and user interaction.
- program.cs        - Main entry point. Handles audio greeting, ASCII art display, and starts the chatbot.
- ASCIIArt.txt      - (Optional) ASCII art displayed at the beginning of the program.
- Audio/greeting.wav - (Optional) Audio greeting file played at startup.

Features  
--------
- Plays a voice greeting (if "Audio/greeting.wav" is present).
- Displays ASCII art from "ASCIIArt.txt" (if available).
- Prompts the user for their name and starts a conversation.
- Responds to specific prompts:
  * how are you
  * what is your purpose
  * password safety
  * phishing
  * safe browsing
- Recognizes the "exit" command to quit the chat.
- Provides fallback responses for unknown inputs.

How to Run  
----------
1. Make sure you have the .NET SDK installed (version 6.0 or later is recommended).
   You can download it from: https://dotnet.microsoft.com/download

2. Place the following files in one folder:
   - chatbot.cs
   - program.cs
   - (Optional) ASCIIArt.txt
   - (Optional) greeting.wav in a subfolder named "Audio"

3. Open a terminal or command prompt in that folder.

4. To run the program:
   - If you do not already have a .NET project, create one:
     dotnet new console -o CyberChatbotApp
     Move chatbot.cs and program.cs into that folder.
     cd CyberChatbotApp

   - Then run the program:
     dotnet run

   - OR, if you already have a project set up:
     dotnet run

Notes  
-----
- The audio greeting requires a WAV file and only works on Windows (uses SoundPlayer).
- If ASCIIArt.txt is not found, the program skips ASCII art display.
- The chatbot provides fixed responses based on exact user inputs.
- This project is intended for educational purposes to raise awareness of cybersecurity.
