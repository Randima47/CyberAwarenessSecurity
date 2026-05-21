using System.Collections.Generic;
using System.Text;

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

            if (memory.ContainsKey(key))
                memory[key] = value;
            else
                memory.Add(key, value);

            return $"Got it, {userName}. I’ll remember your {key} as {value}.";
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

        // Retrieve all stored memory as a summary
        public static string RecallAll(string userName)
        {
            if (memory.Count == 0)
                return $"I don’t have anything stored yet, {userName}. Tell me what you’d like me to remember.";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Here’s what I remember about you, {userName}:");
            foreach (var kvp in memory)
            {
                sb.AppendLine($"- {kvp.Key}: {kvp.Value}");
            }
            return sb.ToString();
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
