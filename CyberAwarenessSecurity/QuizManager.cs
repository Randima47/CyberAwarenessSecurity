using System;
using System.Collections.Generic;

namespace CyberAwarenessSecurity
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public int CorrectIndex { get; set; }
    }

    public static class QuizManager
    {
        private static List<QuizQuestion> questions = new List<QuizQuestion>
        {
            new QuizQuestion {
                Question = "What is phishing?",
                Options = new List<string> { "A cyberattack using fake emails", "A firewall rule", "A type of encryption", "A password manager" },
                CorrectIndex = 0
            },
            new QuizQuestion {
                Question = "Which of these is the strongest password?",
                Options = new List<string> { "123456", "Password!", "MyDog2026", "CorrectHorseBatteryStaple" },
                CorrectIndex = 3
            },
            new QuizQuestion {
                Question = "What does a VPN do?",
                Options = new List<string> { "Encrypts your internet connection", "Stores passwords", "Blocks malware", "Deletes cookies" },
                CorrectIndex = 0
            },
            new QuizQuestion {
                Question = "Two-factor authentication requires:",
                Options = new List<string> { "Two passwords", "Password + another verification", "Biometrics only", "Firewall rules" },
                CorrectIndex = 1
            },
            new QuizQuestion {
                Question = "What is ransomware?",
                Options = new List<string> { "Malware that locks files for payment", "A password cracking tool", "A VPN exploit", "A firewall bypass" },
                CorrectIndex = 0
            }
        };

        private static int currentIndex = 0;
        private static int score = 0;

        public static QuizQuestion GetNextQuestion()
        {
            if (currentIndex < questions.Count)
                return questions[currentIndex];
            return null;
        }

        public static string SubmitAnswer(int selectedIndex)
        {
            if (currentIndex >= questions.Count)
                return "Quiz finished.";

            var question = questions[currentIndex];
            string feedback;

            if (selectedIndex == question.CorrectIndex)
            {
                score++;
                feedback = "Correct!";
            }
            else
            {
                feedback = $"Incorrect. The correct answer was: {question.Options[question.CorrectIndex]}";
            }

            currentIndex++;
            if (currentIndex == questions.Count)
                feedback += $"\nQuiz complete! Your score: {score}/{questions.Count}";

            return feedback;
        }

        public static void ResetQuiz()
        {
            currentIndex = 0;
            score = 0;
        }
    }
}
