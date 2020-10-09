using FluentValidation;

namespace CleanArchitecture.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
    {
        public UpdateItemCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty();
        }
    }
}
