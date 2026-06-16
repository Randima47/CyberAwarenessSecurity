using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CyberAwarenessSecurity
{
    public static class TaskManager
    {
        private static List<TaskItem> tasks = new List<TaskItem>();
        private static int nextId = 1;

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

        public static List<TaskItem> GetTasks()
        {
            return new List<TaskItem>(tasks);
        }

        public static void CompleteTask(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
                task.IsCompleted = true;
        }

        public static void DeleteTask(int id)
        {
            tasks.RemoveAll(t => t.Id == id);
        }
    }
}