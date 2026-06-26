using Finance_Tracker.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Policy;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
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
                PasswordHash TEXT NOT NULL,
                Role TEXT NOT NULL DEFAULT 'Employee',
                DepartmentId INTEGER,
                FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
            );
            CREATE TABLE IF NOT EXISTS Departments (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL UNIQUE
            );
            CREATE TABLE IF NOT EXISTS Categories (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL UNIQUE,
                Type TEXT NOT NULL DEFAULT 'Expense',
                UNIQUE(Name, Type)
            );
            CREATE TABLE IF NOT EXISTS Transactions (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                UserId INTEGER NOT NULL,
                DepartmentId INTEGER,
                Description TEXT,
                Amount REAL NOT NULL,
                Category TEXT,
                Date TEXT NOT NULL,
                Type TEXT NOT NULL,
                Status TEXT NOT NULL DEFAULT 'Pending',
                FOREIGN KEY (UserId) REFERENCES Users(Id)
                FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
            );
            CREATE TABLE IF NOT EXISTS Budgets (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                DepartmentId INTEGER NOT NULL,
                Year INTEGER NOT NULL,
                Month INTEGER NOT NULL,
                Amount INTEGER NOT NULL,
                FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
                UNIQUE(DepartmentId, Year, Month)
            );";

            cmd.ExecuteNonQuery();


            var deptCheckCmd = conn.CreateCommand();
            deptCheckCmd.CommandText = "SELECT COUNT(*) FROM Departments";
            long deptCount = (long)deptCheckCmd.ExecuteScalar();

            if (deptCount == 0)
            {
                string[] defaultDepts = { "مالی", "بازاریابی", "فنی", "منابع انسانی", "فروش", "مدیریت" };
                foreach (var dept in defaultDepts)
                {
                    var insertCmd = conn.CreateCommand();
                    insertCmd.CommandText = "INSERT INTO Departments (Name) VALUES ($name)";
                    insertCmd.Parameters.AddWithValue("$name", dept);
                    insertCmd.ExecuteNonQuery();
                }
            }

            var catCheckCmd = conn.CreateCommand();
            catCheckCmd.CommandText = "SELECT COUNT(*) FROM Categories";
            long catCount = (long)catCheckCmd.ExecuteScalar();

            if (catCount == 0)
            {
                string[] expenseDefaults = { "حقوق", "اجاره", "تجهیزات", "بازاریابی", "مالیات", "سفر", "آب و برق", "سایر" };
                string[] incomeDefaults = { "فروش", "سرمایه‌گذاری", "خدمات", "سایر" };

                foreach (var cat in expenseDefaults)
                    AddCategory(cat, "Expense");
                foreach (var cat in incomeDefaults)
                    AddCategory(cat, "Income");
            }

            //seed adming
            var hash = PasswordHelper.Hash("1234");
            RegisterUser("admin", hash, "Admin", 6);


        }

        public bool RegisterUser(string username, string passwordHash, string Role, int departmentId)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT OR IGNORE INTO Users (Username, PasswordHash, Role, DepartmentId) VALUES ($u, $p, $r, $d)";
            cmd.Parameters.AddWithValue("$u", username);
            cmd.Parameters.AddWithValue("$p", passwordHash);
            cmd.Parameters.AddWithValue("$r", Role);
            cmd.Parameters.AddWithValue("$d", departmentId);
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }

        public User GetUser(string username)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Username, PasswordHash, Role, DepartmentId FROM Users WHERE Username = $u";
            cmd.Parameters.AddWithValue("$u", username);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return new User
            {
                Id = reader.GetInt32(0),
                Username = reader.GetString(1),
                PasswordHash = reader.GetString(2),
                Role = reader.GetString(3),
                DepartmentId = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
            };
        }

        public void AddCategory(string name, string type)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT OR IGNORE INTO Categories (Name, Type) VALUES ($name, $type)";
            cmd.Parameters.AddWithValue("$name", name);
            cmd.Parameters.AddWithValue("$type", type);
            cmd.ExecuteNonQuery();
        }

        public void DeleteCategory(string name, string type)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Categories WHERE Name = $name AND Type = $type";
            cmd.Parameters.AddWithValue("$name", name);
            cmd.Parameters.AddWithValue("$type", type);
            cmd.ExecuteNonQuery();
        }
        public List<string> GetCategories(string type)
        {
            var list = new List<string>();
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Name FROM Categories WHERE Type = $type ORDER BY Name";
            cmd.Parameters.AddWithValue("$type", type);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            return list;
        }

        public List<string> GetAllCategories()
        {
            var list = new List<string>();
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Name FROM Categories ORDER BY Name";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            return list;
        }

        public List<string> GetDepartments()
        {
            var list = new List<string>();
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Name FROM Departments ORDER BY Name";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            return list;
        }

        public int GetDepartmentId(string name)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id FROM Departments WHERE Name = $name";
            cmd.Parameters.AddWithValue("$name", name);
            var result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public string GetDepartmentName(int? id)
        {
            if (id == null) return "نامشخص";
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Name FROM Departments WHERE Id = $id";
            cmd.Parameters.AddWithValue("$id", id);
            var result = cmd.ExecuteScalar();
            return result?.ToString() ?? "نامشخص";
        }

        public void AddDepartment(string name)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT OR IGNORE INTO Departments (Name) VALUES ($name)";
            cmd.Parameters.AddWithValue("$name", name);
            cmd.ExecuteNonQuery();
        }

        public void DeleteDepartment(string name)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Departments WHERE Name = $name";
            cmd.Parameters.AddWithValue("$name", name);
            cmd.ExecuteNonQuery();
        }

        public List<AppTransaction> GetTransactions(int userId)
        {
            var list = new List<AppTransaction>();
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Description, Amount, Category, Date, Type, DepartmentId, Status FROM Transactions WHERE UserId = $uid";
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
                    Type = reader.GetString(5),
                    DepartmentId = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6),
                    Status = reader.GetString(7)
                });
            }
            return list;
        }

        public List<AppTransaction> GetAllTransactions()
        {
            var list = new List<AppTransaction>();
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT Id, DepartmentId, Description, Amount, Category, Date, Type, Status
                        FROM Transactions";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new AppTransaction
                {
                    Id = reader.GetInt32(0),
                    DepartmentId = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                    Description = reader.GetString(2),
                    Amount = reader.GetInt64(3),
                    Category = reader.GetString(4),
                    Date = DateTime.Parse(reader.GetString(5)),
                    Type = reader.GetString(6),
                    Status = reader.GetString(7)
                });
            }
            return list;
        }

        public void AddTransaction(int userId, AppTransaction t, string submitterRole)
        {
            string tStatus = submitterRole == "Admin" ? "Approved" : "Pending";

            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO Transactions (UserId, DepartmentId, Description, Amount, Category, Date, Type, Status)
                            VALUES ($uid, $dept, $desc, $amt, $cat, $date, $type, $status)";
            cmd.Parameters.AddWithValue("$uid", userId);
            cmd.Parameters.AddWithValue("$dept", t.DepartmentId.HasValue ? t.DepartmentId.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("$desc", t.Description);
            cmd.Parameters.AddWithValue("$amt", (double)t.Amount);
            cmd.Parameters.AddWithValue("$cat", t.Category);
            cmd.Parameters.AddWithValue("$date", t.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("$type", t.Type);
            cmd.Parameters.AddWithValue("$status", tStatus);
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
                        SET Description = $desc, Amount = $amt, Category = $cat, Date = $date, Type = $type, DepartmentId = $dept WHERE Id = $id";
            cmd.Parameters.AddWithValue("$desc", t.Description);
            cmd.Parameters.AddWithValue("$amt", (long)t.Amount);
            cmd.Parameters.AddWithValue("$cat", t.Category);
            cmd.Parameters.AddWithValue("$date", t.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("$type", t.Type);
            cmd.Parameters.AddWithValue("$dept", t.DepartmentId.HasValue ? t.DepartmentId.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("$id", t.Id);
            cmd.ExecuteNonQuery();
        }

        public List<AppTransaction> GetPendingTransactions()
        {
            var list = new List<AppTransaction>();
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT Id, Description, Amount, Category, Date, Type, DepartmentId, Status
                        FROM Transactions WHERE Status = 'Pending'";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new AppTransaction
                {
                    Id = reader.GetInt32(0),
                    Description = reader.GetString(1),
                    Amount = reader.GetInt64(2),
                    Category = reader.GetString(3),
                    Date = DateTime.Parse(reader.GetString(4)),
                    Type = reader.GetString(5),
                    DepartmentId = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6),
                    Status = reader.GetString(7)
                });
            }
            return list;
        }

        public void UpdateTransactionStatus(int transactionId, string status)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Transactions SET Status = $status WHERE Id = $id";
            cmd.Parameters.AddWithValue("$status", status);
            cmd.Parameters.AddWithValue("$id", transactionId);
            cmd.ExecuteNonQuery();
        }

        public void SetBudget(int departmentId, int year, int month, long amount)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO Budgets (DepartmentId, Year, Month, Amount)
                        VALUES ($dept, $year, $month, $amount)
                        ON CONFLICT(DepartmentId, Year, Month) 
                        DO UPDATE SET Amount = $amount";
            cmd.Parameters.AddWithValue("$dept", departmentId);
            cmd.Parameters.AddWithValue("$year", year);
            cmd.Parameters.AddWithValue("$month", month);
            cmd.Parameters.AddWithValue("$amount", amount);
            cmd.ExecuteNonQuery();
        }

        public List<Budget> GetBudgets(int year, int month)
        {
            var list = new List<Budget>();
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            SELECT b.Id, b.DepartmentId, d.Name, b.Year, b.Month, b.Amount
            FROM Budgets b
            JOIN Departments d ON b.DepartmentId = d.Id
            WHERE b.Year = $year AND b.Month = $month";
            cmd.Parameters.AddWithValue("$year", year);
            cmd.Parameters.AddWithValue("$month", month);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Budget
                {
                    Id = reader.GetInt32(0),
                    DepartmentId = reader.GetInt32(1),
                    DepartmentName = reader.GetString(2),
                    Year = reader.GetInt32(3),
                    Month = reader.GetInt32(4),
                    Amount = reader.GetInt64(5)
                });
            }
            return list;
        }

        public long GetDepartmentSpending(int departmentId, int year, int month)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT COALESCE(SUM(Amount), 0) FROM Transactions WHERE DepartmentId = $dept AND Type = 'Expense' 
            AND Status = 'Approved' AND strftime('%Y', Date) = $year AND strftime('%m', Date) = $month";
            cmd.Parameters.AddWithValue("$dept", departmentId);
            cmd.Parameters.AddWithValue("$year", year.ToString());
            cmd.Parameters.AddWithValue("$month", month.ToString("D2"));
            return Convert.ToInt64(cmd.ExecuteScalar());
        }
    }
}
