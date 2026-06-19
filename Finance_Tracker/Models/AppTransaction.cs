using System;
using System.Collections.Generic;
using System.Text;

namespace Finance_Tracker.Models
{
    public class AppTransaction
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public long Amount { get; set; }     
        public required string Category { get; set; }
        public DateTime Date { get; set; }
        public required string Type { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string Status { get; set; } = "Pending";
        public string TypeDisplay => Type == "Income" ? "درآمد" : "هزینه";

        public string StatusDisplay => Status switch
        {
            "Approved" => "تأیید شده",
            "Rejected" => "رد شده",
            _ => "در انتظار"
        };
    }
}
