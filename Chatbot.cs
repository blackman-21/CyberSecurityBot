using System;

public class Chatbot
{
    public void StartChat(string userName)
    {
        Console.WriteLine($"\nHow can I help you today?");
        Console.WriteLine("You can ask me about: ");
        Console.WriteLine("I. how are you");
        Console.WriteLine("II. what is you purpose");
        Console.WriteLine("III. password safety");
        Console.WriteLine("IV. phishing");
        Console.WriteLine("V. safe browsing");
        Console.WriteLine("VI. exit");

        while (true)
        {
            Console.Write("\n> ");
            string input = Console.ReadLine()?.ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("I didn't quite understand that. Could you rephrase?");
                continue;
            }

            if (input == "exit")
            {
                Console.WriteLine("Goodbye! Stay safe online.");
                break;
            }

            string response = GetResponse(input);
            Console.WriteLine(response);
        }
    }

    private string GetResponse(string input)
    {
        switch (input)
        {
            case "how are you":
                return "I'm just a bot, but I'm here to help!";
            case "what is your purpose":
                return "I help you learn about cybersecurity and staying safe online.";
            case "password safety":
                return "Password safety is crucial for protecting your online accounts.\n\n"
                     + "- Use strong, unique passwords with at least 12 characters.\n"
                     + "- Include uppercase and lowercase letters, numbers, and symbols.\n"
                     + "- Avoid using birthdays, names, or common words.\n"
                     + "- Enable two-factor authentication (2FA) for extra security.\n"
                     + "- Use a password manager to store complex passwords securely.\n"
                     + "- Regularly update passwords and never share them.";
            case "phishing":
                return "Phishing is a cyberattack where scammers try to steal your information.\n\n"
                     + "- Be cautious of emails or messages asking for personal details.\n"
                     + "- Verify the sender's email address before responding.\n"
                     + "- Avoid clicking on suspicious links or downloading unknown attachments.\n"
                     + "- Contact organizations directly if you're unsure about a request.\n"
                     + "- Keep security software updated to detect phishing attempts.";
            case "safe browsing":
                return "Safe browsing helps protect you from online threats.\n\n"
                     + "- Always use an updated web browser with security settings enabled.\n"
                     + "- Avoid pop-ups and do not download files from unknown sites.\n"
                     + "- Check for HTTPS in the URL before entering personal information.\n"
                     + "- Be cautious when using public Wi-Fi; consider a VPN for extra security.\n"
                     + "- Keep your antivirus and browser extensions up to date.";
            default:
                return "I didn't quite understand that. Try asking about password safety, phishing, or safe browsing.";
        }

    }
}
