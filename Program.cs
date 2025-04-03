using System;
using System.Media;
using System.IO;

class Program
{
    static void Main()
    {
        
        PlayVoiceGreeting();
        DisplayAsciiArt();

        string userName = GetUserName();
        Console.WriteLine($"\nWelcome, {userName}! Let's talk about cybersecurity.");

        Chatbot bot = new Chatbot();
        bot.StartChat(userName);
    }

    

    static void PlayVoiceGreeting()
    {
        try
        {
            SoundPlayer player = new SoundPlayer("Audio/greeting.wav");
            player.PlaySync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error playing audio: " + ex.Message);
        }
    }

    static void DisplayAsciiArt()
    {
        if (File.Exists("ASCIIArt.txt"))
        {
            string[] lines = File.ReadAllLines("ASCIIArt.txt");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("ASCII art file not found.");
        }
    }

    static string GetUserName()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Please enter a valid name.");
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
        }

        return name;
    }
}
