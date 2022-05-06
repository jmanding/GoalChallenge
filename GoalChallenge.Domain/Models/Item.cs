using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Domain.Models
{
    public class Item : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddDays(10);
        public int Type { get; set; }
    }
}
