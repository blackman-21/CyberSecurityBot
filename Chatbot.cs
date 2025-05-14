using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Chatbot
{
    private Dictionary<string, List<string>> topicResponses;
    private Dictionary<string, Action> staticResponses;
    private string userName;
    private string userInterest = "";

    public Chatbot()
    {
        topicResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
    {
        { "phishing", new List<string>
            {
                "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
                "Never click on links in unsolicited messages. Always check the sender's email.",
                "Look out for poor grammar or urgent language in emails – common phishing signs.",
                "Enable spam filters and verify sites before entering sensitive info."
            }
        },
        { "password", new List<string>
            {
                "Use strong, unique passwords for each account.",
                "Avoid personal details like names or birthdates.",
                "Enable two-factor authentication (2FA) wherever possible.",
                "Use a password manager to store complex passwords securely.",
                "Change passwords regularly and don’t reuse them across sites."
            }
        },
        { "privacy", new List<string>
            {
                "Review app permissions regularly.",
                "Limit what you share on social media.",
                "Use browsers with tracking protection.",
                "Always read privacy policies to know how your data is used."
            }
        },
        { "scam", new List<string>
            {
                "Be skeptical of too-good-to-be-true offers online or over the phone.",
                "Never share personal or banking details with unknown sources.",
                "Verify the legitimacy of companies or individuals before sending money.",
                "Report suspected scams to local authorities or consumer protection agencies.",
                "If you feel pressured to act quickly, it's likely a scam – take your time to assess."
            }
        }
    };

        staticResponses = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase)
    {
        { "how are you", () => Respond("I'm just a bot, but I'm always here to help!") },
        { "what is your purpose", () => Respond("I help you learn about cybersecurity and staying safe online.") },
        { "safe browsing", () => Respond(
            "Safe browsing helps protect you from online threats.\n\n" +
            "- Use an updated browser with security features enabled.\n" +
            "- Avoid downloading from suspicious sites.\n" +
            "- Look for HTTPS before entering personal info.\n" +
            "- Use a VPN on public Wi-Fi.\n" +
            "- Keep antivirus software up to date.") }
    };
    


    staticResponses = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase)
        {
            { "how are you", () => Respond("I'm just a bot, but I'm always here to help!") },
            { "what is your purpose", () => Respond("I help you learn about cybersecurity and staying safe online.") },
            { "safe browsing", () => Respond(
                "Safe browsing helps protect you from online threats.\n\n" +
                "- Use an updated browser with security features enabled.\n" +
                "- Avoid downloading from suspicious sites.\n" +
                "- Look for HTTPS before entering personal info.\n" +
                "- Use a VPN on public Wi-Fi.\n" +
                "- Keep antivirus software up to date.") }
        };
    }

    public void StartChat(string name)
    {
        userName = name;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nChatbot: How can I help you today, {userName}?");
        Console.ResetColor();

        PrintMenu();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\n{userName}: ");
            Console.ResetColor();
            string input = Console.ReadLine()?.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Respond("I didn't quite catch that. Could you rephrase?");
                continue;
            }

            if (input == "exit")
            {
                Respond($"Goodbye {userName}, and remember: cybersecurity starts with awareness!");
                break;
            }

            // Special recall check
            if (input.Contains("more") && !string.IsNullOrWhiteSpace(userInterest))
            {
                Respond($"Since you're interested in {userInterest}, here's more advice:");
                ShowRandomTips(userInterest, 3);
                continue;
            }

            if (DetectSentiment(input)) continue;
            if (DetectAndRespondToStatic(input)) continue;
            if (DetectAndRespondToTopic(input)) continue;

            Respond("I'm not sure I understand. Try asking about password safety, phishing, privacy, or safe browsing.");
        }
    }

    private void PrintMenu()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nChatbot: You can ask me about:");
        Console.WriteLine("I. how are you");
        Console.WriteLine("II. what is your purpose");
        Console.WriteLine("III. password safety");
        Console.WriteLine("IV. phishing");
        Console.WriteLine("V. privacy");
        Console.WriteLine("VI. scam");
        Console.WriteLine("VII. safe browsing");
        Console.WriteLine("VIII. exit");
        Console.ResetColor();
    }


    private static void Respond(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Chatbot: ");
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(10); // Typing effect
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    private bool DetectSentiment(string input)
    {
        if (input.Contains("worried") || input.Contains("anxious"))
        {
            Respond("It's okay to feel worried—cyber threats are real, but you're doing the right thing by learning.");
            return true;
        }
        else if (input.Contains("curious") || input.Contains("interested"))
        {
            Respond("That's great! Curiosity is the first step to awareness in cybersecurity.");
            return true;
        }
        else if (input.Contains("frustrated") || input.Contains("confused"))
        {
            Respond("I'm here to help! Let's break it down together.");
            return true;
        }
        return false;
    }

    private bool DetectAndRespondToStatic(string input)
    {
        foreach (var entry in staticResponses)
        {
            if (input.Contains(entry.Key))
            {
                entry.Value.Invoke();
                return true;
            }
        }
        return false;
    }

    private bool DetectAndRespondToTopic(string input)
    {
        foreach (var topic in topicResponses.Keys)
        {
            if (input.Contains(topic))
            {
                userInterest = topic;
                Respond($"Here's what you should know about {topic}:");
                ShowRandomTips(topic, 3); // Show 3 tips only for brevity
                Respond($"I'll remember that you're interested in {topic}, {userName}.");
                return true;
            }
        }
        return false;
    }

    private void ShowRandomTips(string topic, int numberOfTips)
    {
        if (topicResponses.TryGetValue(topic, out var tips))
        {
            var rnd = new Random();
            var selectedTips = tips.OrderBy(x => rnd.Next()).Take(numberOfTips);

            foreach (var tip in selectedTips)
            {
                Respond("- " + tip);
            }
        }
        else
        {
            Respond("I don’t have tips on that topic yet.");
        }
    }
}
