using CyberAwarenessSecurity;
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Input;

namespace CyberAwarenessSecurity
{
    public partial class MainWindow : Window
    {
        private string userName = "Guest";
        private string lastUserInput = "";

        public MainWindow()
        {
            InitializeComponent();
            AddBotMessage("Welcome to CyberSecurity AwarenessBot! Please enter your name to begin.");

            // Bind Enter key to AskButton_Click
            UserInput.KeyDown += UserInput_KeyDown;
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AskButton_Click(sender, e);
                e.Handled = true;
            }
        }

        private void AskButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                AddBotMessage("That looks empty. Please type a question or topic.");
                return;
            }

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

            // Get bot response
            string response = ResponseHandler.GetResponse(input, userName);

            // Show bot response
            AddBotMessage(response);

            // Store last input for follow-up flow
            lastUserInput = input;

            // Clear input
            UserInput.Clear();
        }

        private void FunFactButton_Click(object sender, RoutedEventArgs e)
        {
            string fact = FunFacts.GetRandomFact(userName);
            AddBotMessage(fact);
        }

        private void GlossaryButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                AddBotMessage(GlossaryManager.ShowAllTerms(userName));
                return;
            }

            string definition = GlossaryManager.GetDefinition(input, userName);
            AddBotMessage(definition);

            UserInput.Clear();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ChatDisplay.Document.Blocks.Clear();
            AddBotMessage(MemoryManager.Clear(userName));
            userName = "Guest";
            lastUserInput = "";
        }

        private void AddUserMessage(string text)
        {
            Paragraph p = new Paragraph(new Run($"You: {text}"))
            {
                Foreground = Brushes.Cyan,
                Margin = new Thickness(0, 5, 0, 5)
            };
            ChatDisplay.Document.Blocks.Add(p);

            // Auto-scroll
            ChatDisplay.ScrollToEnd();
        }

        private void AddBotMessage(string text)
        {
            Paragraph p = new Paragraph(new Run($"Bot: {text}"))
            {
                Foreground = Brushes.LightGreen,
                Margin = new Thickness(0, 5, 0, 5)
            };
            ChatDisplay.Document.Blocks.Add(p);

            // Auto-scroll
            ChatDisplay.ScrollToEnd();
        }
    }
}
