using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace CyberAwarenessSecurity
{
    public partial class MainWindow : Window
    {
        private string userName = "Guest";

        public MainWindow()
        {
            InitializeComponent();
            AddBotMessage("Welcome to CyberSecurity AwarenessBot! Please enter your name to begin.");
        }

        // Handle Ask button click
        private void AskButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(input)) return;

            // First message sets user name
            if (userName == "Guest")
            {
                userName = input;
                AddUserMessage(input);
                AddBotMessage($"Nice to meet you, {userName}! Ask me about cybersecurity topics like phishing, passwords, or privacy.");
                UserInput.Clear();
                return;
            }

            // Show user message
            AddUserMessage(input);

            // Get bot response
            string response = ResponseHandler(input);

            // Show bot response
            AddBotMessage(response);

            // Clear input
            UserInput.Clear();
        }

        // Handle Clear button click
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ChatDisplay.Document.Blocks.Clear();
            AddBotMessage("Chat cleared. Start again whenever you’re ready!");
        }

        // Add user message to chat
        private void AddUserMessage(string text)
        {
            Paragraph p = new Paragraph(new Run($"You: {text}"))
            {
                Foreground = Brushes.Cyan
            };
            ChatDisplay.Document.Blocks.Add(p);
        }

        // Add bot message to chat
        private void AddBotMessage(string text)
        {
            Paragraph p = new Paragraph(new Run($"Bot: {text}"))
            {
                Foreground = Brushes.LightGreen
            };
            ChatDisplay.Document.Blocks.Add(p);
        }

        // Core response handler (simplified for GUI)
        private string ResponseHandler(string input)
        {
            input = input.ToLower();

            // Sentiment detection
            if (input.Contains("worried") || input.Contains("scared"))
                return $"It’s understandable to feel that way, {userName}. Scammers can be convincing — let me share a tip: Always verify links before clicking.";

            if (input.Contains("frustrated") || input.Contains("angry"))
                return $"I hear your frustration, {userName}. Cybersecurity can be overwhelming, but small steps like using strong passwords make a big difference.";

            if (input.Contains("curious"))
                return $"Curiosity is great, {userName}! Let’s explore phishing first — attackers often disguise themselves as trusted organisations.";

            // Keyword recognition
            if (input.Contains("password"))
                return $"Strong passwords are your first defense, {userName}. Use a password manager and enable two-factor authentication.";

            if (input.Contains("phishing"))
            {
                string[] tips = {
                    "Be cautious of emails asking for personal info.",
                    "Hover over links before clicking.",
                    "Enable 2FA to reduce damage."
                };
                Random rand = new Random();
                return tips[rand.Next(tips.Length)];
            }

            if (input.Contains("privacy"))
                return $"Privacy matters, {userName}. Review your social media settings and avoid oversharing personal details.";

            // Memory recall
            if (input.Contains("remember my topic"))
                return $"Got it, {userName}. I’ll remember that you’re interested in privacy.";

            if (input.Contains("what do i like"))
                return $"You mentioned privacy earlier, {userName}. Let’s dive deeper into that.";

            // Fallback
            return $"I’m not sure I understand, {userName}. Try asking about phishing, passwords, or privacy.";
        }
    }
}
