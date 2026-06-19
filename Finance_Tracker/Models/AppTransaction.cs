using System;
using System.Collections.Generic;
using System.Text;

namespace Finance_Tracker.Models
{
    public class AppTransaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public long Amount { get; set; }     
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string TypeDisplay => Type == "Income" ? "درآمد" : "هزینه";
    }
}
