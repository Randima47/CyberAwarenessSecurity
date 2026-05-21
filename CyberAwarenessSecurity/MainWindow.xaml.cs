using CyberAwarenessSecurity;
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

            // First input sets user name
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

            // Get bot response from ResponseHandler
            string response = ResponseHandler.GetResponse(input, userName);

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
    }
}

