using System;
using System.Collections.Generic;

namespace CyberAwarenessSecurity
{
    public static class TaskManager
    {
        // Fake in-memory storage
        private static List<TaskItem> tasks = new List<TaskItem>();
        private static int nextId = 1;

        // Add task
        public static void AddTask(string title, string description, DateTime? reminderDate)
        {
            tasks.Add(new TaskItem
            {
                Id = nextId++,
                Title = title,
                Description = description,
                ReminderDate = reminderDate,
                IsCompleted = false
            });
        }

        // Get tasks
        public static List<string> GetTasks()
        {
            var result = new List<string>();
            foreach (var t in tasks)
            {
                string reminder = t.ReminderDate.HasValue ? t.ReminderDate.Value.ToString("yyyy-MM-dd HH:mm") : "No reminder";
                string status = t.IsCompleted ? "Completed" : "Pending";
                result.Add($"{t.Id}: {t.Title} - {t.Description} | {reminder} | {status}");
            }
            return result;
        }

        // Complete task
        public static void CompleteTask(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null) task.IsCompleted = true;
        }

        // Delete task
        public static void DeleteTask(int id)
        {
            tasks.RemoveAll(t => t.Id == id);
        }
    }

    // Helper class
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
