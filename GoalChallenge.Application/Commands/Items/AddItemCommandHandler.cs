using GoalChallenge.Infrastructure.Data.Repositories.Items;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Application.Commands.Items
{
    public class AddItemCommandHandler : AsyncRequestHandler<AddItemCommand>
    {
        private readonly IItemRepository _itemRepository;

        public AddItemCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        }

        protected override async Task Handle(AddItemCommand command, CancellationToken cancellationToken)
        {
            await _itemRepository.AddItem(new Domain.Models.Item() {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.UtcNow,
                ExpirationDate = command.ExpirationDate,
                ModificationDate = DateTime.UtcNow,
                Name = command.Name,
                Type = command.Type
            });
        }
    }
}
