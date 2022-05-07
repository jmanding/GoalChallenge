using FluentValidation;
using GoalChallenge.Application.Commands.Items;

namespace GoalChallenge.Application.Validators
{
    public class AddItemsToInvetoryCommandValidator : AbstractValidator<AddItemsToInvetoryCommand>
    {
        public AddItemsToInvetoryCommandValidator()
        {
            RuleFor(x => x.InventoryInput).NotEmpty();
            RuleFor(x => x.InventoryInput.Name).NotEmpty().MaximumLength(5);

        }
    }
}
