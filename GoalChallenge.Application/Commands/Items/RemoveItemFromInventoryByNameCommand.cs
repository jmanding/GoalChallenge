using GoalChallenge.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Application.Commands.Items
{
    public class RemoveItemFromInventoryByNameCommand : IRequest
    {
        public string Name { get; set; }

        public RemoveItemFromInventoryByNameCommand(string name)
        {
            Name = name;
        }
    }
}
