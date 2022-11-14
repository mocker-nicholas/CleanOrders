using FluentValidation;

namespace CleanOrders.Application.Commands.Accounts
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(UpdateAccountCommand => UpdateAccountCommand.Name)
                .NotEmpty()
                 .MinimumLength(4)
                .MaximumLength(100)
                .WithErrorCode("An account name is required");
            RuleFor(UpdateAccountCommand => UpdateAccountCommand.Email)
                .EmailAddress()
                .WithErrorCode("Please enter a valid email address");
        }
    }
}
