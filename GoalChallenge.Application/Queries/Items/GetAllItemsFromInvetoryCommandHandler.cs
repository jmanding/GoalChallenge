using GoalChallenge.Application.Services.Items.Interfaces;
using GoalChallenge.Domain.Models;
using MediatR;

namespace GoalChallenge.Application.Commands.Items
{
    public class GetAllItemsFromInvetoryCommandHandler : IRequestHandler<GetAllItemsFromInvetoryCommand, List<Inventory>>
    {
        private readonly IItemsService _itemsService;
        

        public GetAllItemsFromInvetoryCommandHandler(IItemsService itemsService)
        {
            _itemsService = itemsService ?? throw new ArgumentNullException(nameof(itemsService));
        }

        public async Task<List<Inventory>> Handle(GetAllItemsFromInvetoryCommand request, CancellationToken cancellationToken)
        {
            return await _itemsService.GetAllItems();
        }
    }
}
