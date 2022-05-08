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
                .MaximumLength(10);

            RuleFor(x => x.Items)
                .NotNull()
                .NotEmpty();
        }
    }
}
