using System.Collections.Generic;
using System.Text;

namespace CyberAwarenessSecurity
{
    namespace CyberAwarenessSecurity
    {
        public static class MemoryManager
        {
            // Dictionary to store user details or interests
            private static Dictionary<string, string> memory = new Dictionary<string, string>();

            // Save information (add or update)
            public static string Remember(string key, string value, string userName)
            {
                if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
                    return $"I couldn’t store that properly, {userName}. Please give me a clear key and value.";

                memory[key] = value; // add or update in one line

                return $"Got it, {userName}. I’ll remember your {key} as {value}.";
            }

            // Universal topic handler: force user into system’s awareness path
            public static string RememberTopic(string input, string userName)
            {
                input = input.ToLower();

                // Normalize phrases
                if (input.StartsWith("remember my topic"))
                    input = input.Replace("remember my topic", "").Trim();
                else if (input.StartsWith("remember "))
                    input = input.Replace("remember", "").Trim();
                else if (input.StartsWith("i like "))
                    input = input.Replace("i like", "").Trim();
                else if (input.StartsWith("favorite topic is "))
                    input = input.Replace("favorite topic is", "").Trim();

                // If sentiment analyzer already forced a topic, use that
                string forcedTopic = SentimentAnalyzer.Analyze(input, userName)?.Topic;

                string topicToRemember = !string.IsNullOrEmpty(forcedTopic) ? forcedTopic : input;

                if (string.IsNullOrWhiteSpace(topicToRemember))
                    return $"Please specify the topic you want me to remember, {userName}. For example: 'I like phishing'.";

                memory["topic"] = topicToRemember;
                return $"Got it, {userName}. I’ll remember you’re interested in {topicToRemember}.";
            }

            // Retrieve information by key
            public static string Recall(string key, string userName)
            {
                if (string.IsNullOrWhiteSpace(key))
                    return $"I need a specific detail to recall, {userName}. Try asking 'What’s my topic?'";

                return memory.ContainsKey(key)
                    ? $"{userName}, you told me your {key} is {memory[key]}."
                    : $"I don’t recall a {key} yet, {userName}. Tell me if you’d like me to remember it.";
            }

            // Retrieve information by key
            public static string Recall(string key, string userName)
            {
                if (string.IsNullOrWhiteSpace(key))
                    return $"I need a specific detail to recall, {userName}. Try asking 'What’s my topic?'";

                if (memory.ContainsKey(key))
                {
                    string value = memory[key];
                    // Auto-attach a tip when recalling topics
                    if (key == "topic")
                    {
                        return $"{userName}, you told me your {key} is {value}.\nTip: " + GetRandomTip(value);
                    }
                    return $"{userName}, you told me your {key} is {value}.";
                }

                return $"I don’t recall a {key} yet, {userName}. Tell me if you’d like me to remember it.";
            }


            // Forget a specific key
            public static string Forget(string key, string userName)
            {
                if (memory.ContainsKey(key))
                {
                    memory.Remove(key);
                    return $"I’ve forgotten your {key}, {userName}.";
                }
                return $"I don’t have a {key} stored, {userName}.";
            }

            // Clear all memory
            public static string Clear(string userName)
            {
                memory.Clear();
                return $"All memory has been cleared, {userName}.";
            }
        }
    }
}