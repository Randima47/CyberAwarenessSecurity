using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CyberAwarenessSecurity
{
    public static class TaskManager
    {
        private static string connectionString = "server=localhost;user=root;password=yourpassword;database=CyberTasks;";

        public static void AddTask(string title, string description, DateTime? reminderDate)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Tasks (Title, Description, ReminderDate, IsCompleted) VALUES (@title, @desc, @reminder, false)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@reminder", reminderDate.HasValue ? reminderDate.Value : (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<string> GetTasks()
        {
            var tasks = new List<string>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Title, Description, ReminderDate, IsCompleted FROM Tasks";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string reminder = reader["ReminderDate"] == DBNull.Value ? "No reminder" : reader["ReminderDate"].ToString();
                        string status = (bool)reader["IsCompleted"] ? "Completed" : "Pending";
                        tasks.Add($"{reader["Id"]}: {reader["Title"]} - {reader["Description"]} | {reminder} | {status}");
                    }
                }
            }
            return tasks;
        }

        public static void CompleteTask(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Tasks SET IsCompleted = true WHERE Id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteTask(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Tasks WHERE Id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
