using FluentValidation;
using SampleNetArch.Application.Commands.Items;

namespace SampleNetArch.Application.Validators
{
    public class AddItemsToInvetoryCommandValidator : AbstractValidator<AddItemsToInvetoryCommand>
    {
        public AddItemsToInvetoryCommandValidator()
        {
            RuleFor(x => x.InventoryInput).NotEmpty();
            RuleFor(x => x.InventoryInput.Name).NotEmpty().MaximumLength(15);

        }
    }
}
