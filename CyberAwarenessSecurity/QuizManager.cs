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
                Question = "What is malware?",
                Options = new List<string> { "Malicious software", "A secure browser", "An antivirus program", "A network cable" },
                CorrectIndex = 0
            },
            new QuizQuestion {
                Question = "Which of the following is an example of biometric authentication?",
                Options = new List<string> { "Password", "PIN", "Fingerprint scan", "Security question" },
                CorrectIndex = 2
            },
           new QuizQuestion {
               Question = "What is the purpose of a firewall?",
               Options = new List<string> { "To monitor and filter network traffic", "To store passwords", "To create backups", "To encrypt files" },
               CorrectIndex = 0
           },
           new QuizQuestion {
               Question = "Which type of attack attempts to guess passwords automatically?",
               Options = new List<string> { "Brute force attack", "Phishing attack", "DDoS attack", "Spoofing attack" },
               CorrectIndex = 0
           },
           new QuizQuestion {
               Question = "What should you do if you receive a suspicious email?",
               Options = new List<string> { "Click the links immediately", "Reply with personal information", "Delete or report it", "Forward it to everyone" },
               CorrectIndex = 2
           },
           new QuizQuestion {
               Question = "What does HTTPS indicate?",
               Options = new List<string> { "A secure website connection", "A faster website", "A website without ads", "A private browser" },
               CorrectIndex = 0
           },
           new QuizQuestion {
               Question = "Which of these is a common sign of a phishing website?",
               Options = new List<string> { "Misspelled URLs", "HTTPS enabled", "Fast loading speed", "Professional design" },
               CorrectIndex = 0
           },
           new QuizQuestion {
               Question = "Why is it important to update software regularly?",
               Options = new List<string> { "To fix security vulnerabilities", "To increase internet speed", "To reduce storage space", "To change passwords" },
               CorrectIndex = 0
           },
           new QuizQuestion {
               Question = "What is social engineering?",
               Options = new List<string> { "Manipulating people to reveal information", "Building social media apps", "Creating secure networks", "Encrypting data" },
               CorrectIndex = 0
           },
           new QuizQuestion {
               Question = "Which device is most vulnerable when connected to public Wi-Fi without protection?",
               Options = new List<string> { "Any connected device", "Printer only", "Router only", "USB drive" },
               CorrectIndex = 0
           },
           new QuizQuestion {
               Question = "What is a data breach?",
               Options = new List<string> { "Unauthorized access to sensitive data", "A software update", "A network upgrade", "A backup process" },
               CorrectIndex = 0
           },
           new QuizQuestion {
               Question = "Which of the following is a good cybersecurity practice?",
               Options = new List<string> { "Sharing passwords with friends", "Using the same password everywhere", "Enabling multi-factor authentication", "Ignoring software updates" },
               CorrectIndex = 2
           },
           new QuizQuestion {
               Question = "What does antivirus software do?",
               Options = new List<string> { "Detects and removes malicious software", "Creates passwords", "Speeds up internet access", "Encrypts websites" },
               CorrectIndex = 0
           },
           new QuizQuestion {
               Question = "What is a DDoS attack?",
               Options = new List<string> { "Overwhelming a system with traffic", "Stealing passwords", "Encrypting files", "Creating backups" },
               CorrectIndex = 0
           },
           new QuizQuestion {
               Question = "What should you do before entering sensitive information on a website?",
               Options = new List<string> { "Check for HTTPS and a trusted URL", "Disable antivirus", "Use public Wi-Fi", "Share the link with strangers" },
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
