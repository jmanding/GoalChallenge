using GoalChallenge.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Application.Commands.Items
{
    public class AddItemToInvetoryCommand : IRequest
    {
        public Inventory Inventory { get; set; }

        public AddItemToInvetoryCommand(Inventory inventory)
        {
            Inventory = inventory;
        }
    }
}
