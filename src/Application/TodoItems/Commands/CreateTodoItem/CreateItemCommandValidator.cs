using FluentValidation;

namespace CleanArchitecture.Application.Items.Commands.CreateItem
{
    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty();
        }
    }
}
