using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Common.Models
{
    public class ItemInput
    {
        public string? Name { get; set; }
        public DateTime ExpirationDate { get; set; } 
        public int Type { get; set; }
    }
}
