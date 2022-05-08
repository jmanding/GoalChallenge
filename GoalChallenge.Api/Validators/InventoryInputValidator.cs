using FluentValidation;
using GoalChallenge.Common.Models;

namespace GoalChallenge.Api.Validators
{
    /// <summary>
    /// InventoryInput Validator 
    /// </summary>
    public class InventoryInputValidator : AbstractValidator<InventoryInput>
    {
        /// <summary>
        /// InventoryInput Validator Constructor
        /// </summary>
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
