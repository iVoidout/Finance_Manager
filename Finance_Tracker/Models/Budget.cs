using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Tracker.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } // for display
        public int Year { get; set; }
        public int Month { get; set; }
        public long Amount { get; set; }
        public long Spent { get; set; } // calculated, not stored
    }
}
