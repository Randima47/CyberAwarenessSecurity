using System.Collections.Generic;

namespace CyberAwarenessSecurity
{
    public static class MemoryManager
    {
        // Dictionary to store user details or interests
        private static Dictionary<string, string> memory = new Dictionary<string, string>();

        // Save information
        public static void Remember(string key, string value)
        {
            if (memory.ContainsKey(key))
                memory[key] = value;
            else
                memory.Add(key, value);
        }

        // Retrieve information
        public static string Recall(string key)
        {
            return memory.ContainsKey(key) ? memory[key] : null;
        }

        // Clear memory (optional, for reset)
        public static void Clear()
        {
            memory.Clear();
        }
    }
}
