using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Application.Commands.Items
{
    public class AddItemCommand : IRequest
    {
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Type { get; set; }

        public AddItemCommand(string name, DateTime expirationDate, int type)
        {
            Name = name;
            ExpirationDate = expirationDate;
            Type = type;
        }
    }
}
