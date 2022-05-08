﻿using MediatR;

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
