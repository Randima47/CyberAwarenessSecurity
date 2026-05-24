using System.Collections.Generic;
using System.Text;

namespace CyberAwarenessSecurity
{
    public static class MemoryManager
    {
        private static Dictionary<string, string> memory = new Dictionary<string, string>();

        public static string Remember(string key, string value, string userName)
        {
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
                return $"I couldn’t store that properly, {userName}. Please give me a clear key and value.";

            memory[key] = value;
            return $"Got it, {userName}. I’ll remember your {key} as {value}.";
        }

        public static string RememberTopic(string input, string userName)
        {
            input = input.ToLower();

            if (input.StartsWith("remember my topic"))
                input = input.Replace("remember my topic", "").Trim();
            else if (input.StartsWith("remember "))
                input = input.Replace("remember", "").Trim();
            else if (input.StartsWith("i like "))
                input = input.Replace("i like", "").Trim();
            else if (input.StartsWith("favorite topic is "))
                input = input.Replace("favorite topic is", "").Trim();

            string topicToRemember = input;

            if (string.IsNullOrWhiteSpace(topicToRemember))
                return $"Please specify the topic you want me to remember, {userName}. For example: 'I like phishing'.";

            memory["topic"] = topicToRemember;
            return $"Got it, {userName}. I’ll remember you’re interested in {topicToRemember}.";
        }

        public static string Recall(string key, string userName)
        {
            if (string.IsNullOrWhiteSpace(key))
                return $"I need a specific detail to recall, {userName}. Try asking 'What’s my topic?'";

            if (memory.ContainsKey(key))
            {
                string value = memory[key];
                if (key == "topic")
                    return $"{userName}, you told me your {key} is {value}.\nTip: " + ResponseHandler.GetRandomTip(value);
                return $"{userName}, you told me your {key} is {value}.";
            }

            return $"I don’t recall a {key} yet, {userName}. Tell me if you’d like me to remember it.";
        }

        public static string Forget(string key, string userName)
        {
            if (memory.ContainsKey(key))
            {
                memory.Remove(key);
                return $"I’ve forgotten your {key}, {userName}.";
            }
            return $"I don’t have a {key} stored, {userName}.";
        }

        public static string Clear(string userName)
        {
            memory.Clear();
            return $"All memory has been cleared, {userName}.";
        }
    }
}
