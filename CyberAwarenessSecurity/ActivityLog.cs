using System;
using System.Collections.Generic;

namespace CyberAwarenessSecurity
{
    public class ActivityEntry
    {
        public DateTime Timestamp { get; set; }
        public string Action { get; set; }
    }

    public static class ActivityLog
    {
        private static List<ActivityEntry> entries = new List<ActivityEntry>();

        public static void Add(string action)
        {
            entries.Add(new ActivityEntry
            {
                Timestamp = DateTime.Now,
                Action = action
            });
        }

        public static List<ActivityEntry> GetEntries()
        {
            return new List<ActivityEntry>(entries);
        }

        public static void Clear()
        {
            entries.Clear();
        }
    }
}
