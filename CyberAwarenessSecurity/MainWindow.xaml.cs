using CyberAwarenessSecurity;
using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace CyberAwarenessSecurity
{
    public partial class MainWindow : Window
    {
        private string userName = "Guest";
        private string lastUserInput = "";

        public MainWindow()
        {
            InitializeComponent();

            // Play greeting audio on startup
            try
            {
                SoundPlayer player = new SoundPlayer("AWARENESSBOT.wav");
                player.Load();
                player.Play();
            }
            catch (Exception ex)
            {
                AddBotMessage($"(Audio greeting failed: {ex.Message})");
            }

            AddBotMessage("Welcome to CyberSecurity AwarenessBot! Please enter your name to begin.");

            // Bind Enter key to AskButton_Click
            UserInput.KeyDown += UserInput_KeyDown;

            // Load tasks on startup
            RefreshTaskList();
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
                LogAction($"User set name: {userName}");
                return;
            }

            // Show user message
            AddUserMessage(input);
            LogAction($"User asked: {input}");

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
            LogAction("Displayed fun fact.");
        }

        private void GlossaryButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                AddBotMessage(GlossaryManager.ShowAllTerms(userName));
                LogAction("Displayed full glossary.");
                return;
            }

            string definition = GlossaryManager.GetDefinition(input, userName);
            AddBotMessage(definition);
            LogAction($"Looked up glossary term: {input}");

            UserInput.Clear();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ChatDisplay.Document.Blocks.Clear();
            AddBotMessage(MemoryManager.Clear(userName));
            userName = "Guest";
            lastUserInput = "";
            LogAction("Chat cleared and memory reset.");
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

        // -------------------------------
        // Task Panel Event Handlers
        // -------------------------------

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitle.Text.Trim();
            string description = TaskDescription.Text.Trim();
            DateTime? reminder = TaskReminder.SelectedDate;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description))
            {
                AddBotMessage("Please enter both a title and description for the task.");
                return;
            }

            try
            {
                TaskManager.AddTask(title, description, reminder);
                AddBotMessage($"Task '{title}' added successfully.");
                RefreshTaskList();
                TaskTitle.Clear();
                TaskDescription.Clear();
                TaskReminder.SelectedDate = null;

                LogAction($"Task added: {title}");
            }
            catch (Exception ex)
            {
                AddBotMessage($"Error adding task: {ex.Message}");
            }
        }

        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem == null)
            {
                AddBotMessage("Please select a task to mark as complete.");
                return;
            }

            var selectedTask = (dynamic)TaskList.SelectedItem;
            int id = selectedTask.Id;

            try
            {
                TaskManager.CompleteTask(id);
                AddBotMessage($"Task '{selectedTask.Title}' marked as completed.");
                RefreshTaskList();

                LogAction($"Task completed: {selectedTask.Title}");
            }
            catch (Exception ex)
            {
                AddBotMessage($"Error completing task: {ex.Message}");
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem == null)
            {
                AddBotMessage("Please select a task to delete.");
                return;
            }

            var selectedTask = (dynamic)TaskList.SelectedItem;
            int id = selectedTask.Id;

            try
            {
                TaskManager.DeleteTask(id);
                AddBotMessage($"Task '{selectedTask.Title}' deleted.");
                RefreshTaskList();

                LogAction($"Task deleted: {selectedTask.Title}");
            }
            catch (Exception ex)
            {
                AddBotMessage($"Error deleting task: {ex.Message}");
            }
        }

        private void RefreshTaskList()
        {
            try
            {
                var tasks = TaskManager.GetTasks();
                TaskList.ItemsSource = null;
                TaskList.ItemsSource = tasks;
            }
            catch (Exception ex)
            {
                AddBotMessage($"Error loading tasks: {ex.Message}");
            }
        }

        // -------------------------------
        // Quiz Panel Event Handlers
        // -------------------------------

        private void StartQuiz_Click(object sender, RoutedEventArgs e)
        {
            QuizManager.ResetQuiz();
            QuizFeedback.Text = "";
            LoadNextQuestion();
            LogAction("Quiz started.");
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            LoadNextQuestion();
            LogAction("Moved to next quiz question.");
        }

        private void ResetQuiz_Click(object sender, RoutedEventArgs e)
        {
            QuizManager.ResetQuiz();
            QuizQuestionText.Text = "Press 'Start Quiz' to begin.";
            QuizOptionsPanel.Children.Clear();
            QuizFeedback.Text = "";
            LogAction("Quiz reset.");
        }

        private void LoadNextQuestion()
        {
            var question = QuizManager.GetNextQuestion();

            QuizOptionsPanel.Children.Clear();

            if (question == null)
            {
                QuizQuestionText.Text = "Quiz finished!";
                QuizFeedback.Text = $"Quiz complete! Your score: {QuizManager.GetScore()}";
                LogAction("Quiz finished.");
                return;
            }

            QuizQuestionText.Text = question.Question;

            //  Freeze local reference 
            var currentQuestion = question;

            for (int i = 0; i < currentQuestion.Options.Count; i++)
            {
                int optionIndex = i;

                Button optionButton = new Button
                {
                    Content = currentQuestion.Options[i],
                    Width = 300,
                    Height = 30,
                    Margin = new Thickness(0, 5, 0, 5),
                    Background = Brushes.DarkSlateGray,
                    Foreground = Brushes.White,
                    FontWeight = FontWeights.Bold
                };

                optionButton.Click += (s, e) =>
                {
                    // prevent double clicks causing confusion
                    optionButton.IsEnabled = false;

                    string feedback = QuizManager.SubmitAnswer(optionIndex);
                    QuizFeedback.Text = feedback;

                    LogAction($"Answered: {currentQuestion.Question}");
                };

                QuizOptionsPanel.Children.Add(optionButton);
            }
        }

        // -------------------------------
        // Activity Log Event Handlers
        // -------------------------------

        private void LogAction(string action)
        {
            ActivityLog.Add(action);

            // update UI immediately (like Quiz feedback)
            ActivityList.ItemsSource = ActivityLog.GetEntries();
        }

        private void ClearLog_Click(object sender, RoutedEventArgs e)
        {
            ActivityLog.Clear();

            ActivityList.ItemsSource = ActivityLog.GetEntries();

            LogAction("Activity log cleared.");
        }
    }
}
