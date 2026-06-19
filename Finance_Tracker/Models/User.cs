using System;
using System.Collections.Generic;
using System.Text;

namespace Finance_Tracker.Models
{
    public class User
    {
        public required int Id { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string Role { get; set; }

        public int? DepartmentId { get; set; }
    }
}
