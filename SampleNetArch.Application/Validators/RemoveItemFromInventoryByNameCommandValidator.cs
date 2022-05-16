using FluentValidation;
using GoalChallenge.Application.Commands.Items;

namespace GoalChallenge.Application.Validators
{
    public class RemoveItemFromInventoryByNameCommandValidator : AbstractValidator<RemoveItemFromInventoryByNameCommand>
    {
        public RemoveItemFromInventoryByNameCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
