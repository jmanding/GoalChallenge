using FluentValidation;
using GoalChallenge.Common.Models;

namespace GoalChallenge.Api.Validators
{
    public class InventoryInputValidator : AbstractValidator<InventoryInput>
    {
        public InventoryInputValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(x => x.Description)
                .MaximumLength(200);

            RuleFor(x => x.Items)
                .NotNull()
                .NotEmpty();
        }
    }
}
