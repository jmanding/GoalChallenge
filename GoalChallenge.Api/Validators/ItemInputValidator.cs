using FluentValidation;
using GoalChallenge.Common.Models;

namespace GoalChallenge.Api.Validators
{
    public class ItemInputValidator : AbstractValidator<ItemInput>
    {
        public ItemInputValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(c => c.Type)
                .NotEmpty();
        }
    }
}
