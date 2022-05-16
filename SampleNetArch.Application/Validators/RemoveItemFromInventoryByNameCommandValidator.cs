using FluentValidation;
using SampleNetArch.Application.Commands.Items;

namespace SampleNetArch.Application.Validators
{
    public class RemoveItemFromInventoryByNameCommandValidator : AbstractValidator<RemoveItemFromInventoryByNameCommand>
    {
        public RemoveItemFromInventoryByNameCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
