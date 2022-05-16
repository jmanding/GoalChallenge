using FluentValidation;
using SampleNetArch.Common.Models;

namespace SampleNetArch.Api.Validators
{
    /// <summary>
    /// ItemInputValidator Class
    /// </summary>
    public class ItemInputValidator : AbstractValidator<ItemInput>
    {
        /// <summary>
        /// Validator item inputs
        /// </summary>
        public ItemInputValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(c => c.Type)
                .NotEmpty();
        }
    }
}
