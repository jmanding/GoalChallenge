using GoalChallenge.Domain.Models;
using MediatR;

namespace GoalChallenge.Application.Commands.Items
{
    public class GetAllItemsFromInvetoryCommand : IRequest<List<Inventory>>
    {
    }
}
