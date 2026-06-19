using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Finance_Tracker.Models;
namespace Finance_Tracker.Helpers
{

    public class DatabaseHelper
    {
        private const string DbPath = "finance.db";
        private string ConnectionString => $"Data Source={DbPath}";

        public void InitialiseDatabase()
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT NOT NULL UNIQUE,
                PasswordHash TEXT NOT NULL
            );
            CREATE TABLE IF NOT EXISTS Transactions (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                UserId INTEGER NOT NULL,
                Description TEXT,
                Amount REAL NOT NULL,
                Category TEXT,
                Date TEXT NOT NULL,
                Type TEXT NOT NULL,
                FOREIGN KEY (UserId) REFERENCES Users(Id)
            );";
            cmd.ExecuteNonQuery();
        }

        public bool RegisterUser(string username, string passwordHash)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT OR IGNORE INTO Users (Username, PasswordHash) VALUES ($u, $p)";
            cmd.Parameters.AddWithValue("$u", username);
            cmd.Parameters.AddWithValue("$p", passwordHash);
            return cmd.ExecuteNonQuery() > 0; 
        }

        public User GetUser(string username)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Username, PasswordHash FROM Users WHERE Username = $u";
            cmd.Parameters.AddWithValue("$u", username);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return new User
            {
                Id = reader.GetInt32(0),
                Username = reader.GetString(1),
                PasswordHash = reader.GetString(2)
            };
        }

        public List<AppTransaction> GetTransactions(int userId)
        {
            var list = new List<AppTransaction>();
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Description, Amount, Category, Date, Type FROM Transactions WHERE UserId = $uid";
            cmd.Parameters.AddWithValue("$uid", userId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new AppTransaction
                {
                    Id = reader.GetInt32(0),
                    Description = reader.GetString(1),
                    Amount = (long)reader.GetDouble(2),
                    Category = reader.GetString(3),
                    Date = DateTime.Parse(reader.GetString(4)),
                    Type = reader.GetString(5)
                });
            }
            return list;
        }

        public void AddTransaction(int userId, AppTransaction t)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO Transactions (UserId, Description, Amount, Category, Date, Type)
                            VALUES ($uid, $desc, $amt, $cat, $date, $type)";
            cmd.Parameters.AddWithValue("$uid", userId);
            cmd.Parameters.AddWithValue("$desc", t.Description);
            cmd.Parameters.AddWithValue("$amt", (double)t.Amount);
            cmd.Parameters.AddWithValue("$cat", t.Category);
            cmd.Parameters.AddWithValue("$date", t.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("$type", t.Type);
            cmd.ExecuteNonQuery();
        }

        public void DeleteTransaction(int id)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Transactions WHERE Id = $id";
            cmd.Parameters.AddWithValue("$id", id);
            cmd.ExecuteNonQuery();
        }

        public void UpdateTransaction(AppTransaction t)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE Transactions 
                        SET Description = $desc, Amount = $amt, Category = $cat, Date = $date, Type = $type
                        WHERE Id = $id";
            cmd.Parameters.AddWithValue("$desc", t.Description);
            cmd.Parameters.AddWithValue("$amt", (long)t.Amount);
            cmd.Parameters.AddWithValue("$cat", t.Category);
            cmd.Parameters.AddWithValue("$date", t.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("$type", t.Type);
            cmd.Parameters.AddWithValue("$id", t.Id);
            cmd.ExecuteNonQuery();
        }

    }
}
