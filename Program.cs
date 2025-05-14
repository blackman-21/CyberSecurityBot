using System;
using System.IO;
using System.Media;
using System.Threading;

class Program
{
    static void Main()
    {


        PlayVoiceGreeting();
        DisplayAsciiArt();

        string userName = GetUserName();
        PrintTyping($"\nWelcome, {userName}! Let's talk about cybersecurity.\n");

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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error playing audio: " + ex.Message);
            Console.ResetColor();
        }
    }

    static void DisplayAsciiArt()
    {
        if (File.Exists("ASCIIArt.txt"))
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (string line in File.ReadAllLines("ASCIIArt.txt"))
            {
                Console.WriteLine(line);
                Thread.Sleep(10);
            }
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("ASCII art file not found.");
            Console.ResetColor();
        }
    }

    static string GetUserName()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Enter your name: ");
        Console.ResetColor();
        string name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter a valid name.");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your name: ");
            Console.ResetColor();
            name = Console.ReadLine();
        }

        return name;
    }



    public static void DisplaySection(string title)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\n{new string('-', 40)}");
        Console.WriteLine($"--- {title.ToUpper()} ---");
        Console.WriteLine($"{new string('-', 40)}\n");
        Console.ResetColor();
    }

    public static void PrintTyping(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(15);
        }
        Console.WriteLine();
        Console.ResetColor();
    }
}